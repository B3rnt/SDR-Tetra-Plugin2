using System;
using System.Text;

namespace SDRSharp.Tetra
{
    unsafe class MmLevel
    {
        // Ported (cleaned) from the extended SDRtetra source: Class18 rules_0..rules_5
        private readonly Rules[] _locationUpdateAcceptRules = new Rules[]
        {
            new Rules(GlobalNames.Location_update_accept_type, 3, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Options_bit, 1, RulesType.Options_bit, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.MM_SSI, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 24, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 16, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 14, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 6, RulesType.Reserved, 0, 0, 0)
        };

        private readonly Rules[] _locationUpdateCommandRules = new Rules[]
        {
            new Rules(GlobalNames.Group_identity_report, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Cipher_control, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Ciphering_parameters, 32, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Group_identity_acknowledgement_request, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Location_update_type, 2, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.MM_SSI, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.MM_Address_extension, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Reserved, 2, RulesType.Reserved, 0, 0, 0)
        };

        private readonly Rules[] _locationUpdateRejectRules = new Rules[]
        {
            new Rules(GlobalNames.Reject_cause, 4, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Options_bit, 1, RulesType.Options_bit, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.MM_SSI, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 24, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 16, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 14, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 6, RulesType.Reserved, 0, 0, 0)
        };

        private readonly Rules[] _locationUpdateProceedingRules = new Rules[]
        {
            new Rules(GlobalNames.Location_update_type, 2, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Options_bit, 1, RulesType.Options_bit, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.MM_SSI, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 24, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 16, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 14, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.Presence_bit, 1, RulesType.Presence_bit, 1, 0, 0),
            new Rules(GlobalNames.Reserved, 6, RulesType.Reserved, 0, 0, 0)
        };

        private readonly Rules[] _attachDetachGroupIdentityRules = new Rules[]
        {
            new Rules(GlobalNames.Group_identity_accept_reject, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Group_identity_attach_detach_mode, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Group_identity_report, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.MM_vGSSI, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Cipher_control, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Ciphering_parameters, 32, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Group_identity_acknowledgement_request, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Reserved, 3, RulesType.Reserved, 0, 0, 0)
        };

        private readonly Rules[] _attachDetachGroupIdentityAckRules = new Rules[]
        {
            new Rules(GlobalNames.Group_identity_attach_detach_mode, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Group_identity_accept_reject, 1, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Reserved, 2, RulesType.Reserved, 0, 0, 0),
            new Rules(GlobalNames.MM_SSI, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.MM_Address_extension, 24, RulesType.Direct, 0, 0, 0),
            new Rules(GlobalNames.Reserved, 4, RulesType.Reserved, 0, 0, 0)
        };

        public void Parse(LogicChannel channelData, int offset, ReceivedData result)
        {
            int mmStart = offset;

            if (offset + 4 > channelData.Length)
            {
                result.SetValue(GlobalNames.OutOfBuffer, 1);
                return;
            }

            MmPduType mmType = (MmPduType)TetraUtils.BitsToInt32(channelData.Ptr, offset, 4);
            result.SetValue(GlobalNames.MM_PDU_Type, (int)mmType);
            offset += 4;

            // Decode what we can safely.
            switch (mmType)
            {
                case MmPduType.D_LOCATION_UPDATE_ACCEPT:
                    offset = Global.ParseParams(channelData, offset, _locationUpdateAcceptRules, result);
                    break;

                case MmPduType.D_LOCATION_UPDATE_COMMAND:
                    offset = Global.ParseParams(channelData, offset, _locationUpdateCommandRules, result);
                    break;

                case MmPduType.D_LOCATION_UPDATE_REJECT:
                    offset = Global.ParseParams(channelData, offset, _locationUpdateRejectRules, result);
                    break;

                case MmPduType.D_LOCATION_UPDATE_PROCEEDING:
                    offset = Global.ParseParams(channelData, offset, _locationUpdateProceedingRules, result);
                    break;

                case MmPduType.D_ATTACH_DETACH_GROUP_IDENTITY:
                    offset = Global.ParseParams(channelData, offset, _attachDetachGroupIdentityRules, result);
                    break;

                case MmPduType.D_ATTACH_DETACH_GROUP_IDENTITY_ACKNOWLEDGEMENT:
                    offset = Global.ParseParams(channelData, offset, _attachDetachGroupIdentityAckRules, result);
                    break;

                case MmPduType.D_MM_STATUS:
                    if (offset + 6 <= channelData.Length)
                    {
                        result.SetValue(GlobalNames.Status_downlink, TetraUtils.BitsToInt32(channelData.Ptr, offset, 6));
                        offset += 6;
                    }
                    else
                    {
                        result.SetValue(GlobalNames.OutOfBuffer, 1);
                    }
                    break;

                case MmPduType.MM_PDU_FUNCTION_NOT_SUPPORTED:
                    if (offset + 4 <= channelData.Length)
                    {
                        result.SetValue(GlobalNames.Not_supported_sub_PDU_type, TetraUtils.BitsToInt32(channelData.Ptr, offset, 4));
                        offset += 4;
                    }
                    else
                    {
                        result.SetValue(GlobalNames.OutOfBuffer, 1);
                    }
                    break;

                case MmPduType.D_OTAR:
                    // OTAR subtype is typically 4 bits
                    if (offset + 4 <= channelData.Length)
                    {
                        int sub = TetraUtils.BitsToInt32(channelData.Ptr, offset, 4);
                        result.SetValue(GlobalNames.Otar_sub_type, sub);
                        offset += 4;

                        // Best-effort: many OTAR sub-PDUs carry an 8-bit CCK_id early in payload
                        if (offset + 8 <= channelData.Length)
                        {
                            result.SetValue(GlobalNames.CCK_id, TetraUtils.BitsToInt32(channelData.Ptr, offset, 8));
                            offset += 8;
                        }
                    }
                    else
                    {
                        result.SetValue(GlobalNames.OutOfBuffer, 1);
                    }
                    break;

                case MmPduType.D_AUTHENTICATION:
                    // In your captures: auth_sub=0 looks like "BS demands authentication"
                    // and auth_sub=2 matches "result to MS authentication".
                    if (offset + 2 <= channelData.Length)
                    {
                        int sub = TetraUtils.BitsToInt32(channelData.Ptr, offset, 2);
                        result.SetValue(GlobalNames.Authentication_sub_type, sub);
                        offset += 2;

                        // Best-effort: some implementations include a 6-bit status in RESULT / REJECT
                        if ((sub == (int)D_AuthenticationPduSubType.Result || sub == (int)D_AuthenticationPduSubType.Reject) &&
                            offset + 6 <= channelData.Length)
                        {
                            result.SetValue(GlobalNames.Authentication_status, TetraUtils.BitsToInt32(channelData.Ptr, offset, 6));
                            offset += 6;
                        }
                    }
                    else
                    {
                        result.SetValue(GlobalNames.OutOfBuffer, 1);
                    }
                    break;

                case MmPduType.D_CK_CHANGE_DEMAND:
                    if (offset + 1 <= channelData.Length)
                    {
                        result.SetValue(GlobalNames.CK_provision_flag, TetraUtils.BitsToInt32(channelData.Ptr, offset, 1));
                        offset += 1;
                    }
                    else
                    {
                        result.SetValue(GlobalNames.OutOfBuffer, 1);
                    }
                    break;

                default:
                    // Other types: we still log raw, so nothing is lost.
                    break;
            }

            // Always log the MM PDU (type + decoded fields + raw payload)
            MmLogger.LogMmPdu(channelData, mmStart, channelData.Length - mmStart, result);
        }
    }

    internal static unsafe class MmLogger
    {
        private const string DefaultPath = "mm_messages.log";

        public static void LogMmPdu(LogicChannel channelData, int bitOffset, int bitLength, ReceivedData parsed)
        {
            try
            {
                var sb = new StringBuilder(512);
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.Append("  ");

                // LA (Location Area) if available
                int la = parsed.Value(GlobalNames.Location_Area);
                if (la > 0)
                {
                    sb.Append("[LA: ");
                    sb.Append(la.ToString().PadLeft(4));
                    sb.Append("]   ");
                }
                else
                {
                    sb.Append("            ");
                }

                MmPduType mmType = (MmPduType)parsed.Value(GlobalNames.MM_PDU_Type);

                // Best-effort identities from earlier layers (MAC) or MM itself
                int ssi = parsed.Value(GlobalNames.SSI);
                if (ssi <= 0) ssi = parsed.Value(GlobalNames.MM_SSI);

                int gssi = parsed.Value(GlobalNames.GSSI);
                if (gssi <= 0) gssi = parsed.Value(GlobalNames.MM_vGSSI);

                int cckId = parsed.Value(GlobalNames.CCK_id);

                // Human-friendly lines similar to SDRtetra
                switch (mmType)
                {
                    case MmPduType.D_AUTHENTICATION:
                    {
                        int sub = parsed.Value(GlobalNames.Authentication_sub_type);
                        int status = parsed.Value(GlobalNames.Authentication_status);

                        // Map your observed values (0 = demand, 2 = result) + safe fallbacks
                        if (sub == (int)D_AuthenticationPduSubType.Demand)
                        {
                            sb.Append("BS demands authentication");
                            if (ssi > 0) { sb.Append(": SSI: "); sb.Append(ssi); }
                        }
                        else if (sub == (int)D_AuthenticationPduSubType.Result)
                        {
                            sb.Append("BS result to MS authentication: ");
                            sb.Append(AuthenticationStatusToString(status));
                            if (ssi > 0) { sb.Append(" SSI: "); sb.Append(ssi); }
                            if (status >= 0)
                            {
                                sb.Append(" - ");
                                sb.Append(AuthenticationStatusToString(status));
                            }
                        }
                        else if (sub == (int)D_AuthenticationPduSubType.Reject)
                        {
                            sb.Append("BS reject authentication");
                            if (ssi > 0) { sb.Append(": SSI: "); sb.Append(ssi); }
                            if (status >= 0)
                            {
                                sb.Append(" - ");
                                sb.Append(AuthenticationStatusToString(status));
                            }
                        }
                        else
                        {
                            // Generic
                            sb.Append("MM D_AUTHENTICATION");
                            if (sub >= 0) { sb.Append(" auth_sub="); sb.Append(sub); }
                            if (ssi > 0) { sb.Append(" SSI: "); sb.Append(ssi); }
                        }
                        break;
                    }

                    case MmPduType.D_OTAR:
                    {
                        int sub = parsed.Value(GlobalNames.Otar_sub_type);
                        sb.Append("OTAR");
                        if (sub >= 0) { sb.Append(" otar_sub="); sb.Append(sub); }
                        if (cckId > 0) { sb.Append(" CCK_id: "); sb.Append(cckId); }
                        if (ssi > 0) { sb.Append(" SSI: "); sb.Append(ssi); }
                        if (gssi > 0) { sb.Append(" GSSI: "); sb.Append(gssi); }
                        break;
                    }

                    case MmPduType.D_LOCATION_UPDATE_ACCEPT:
                    {
                        // In SDRtetra this appears as: "MS request for registration/authentication ACCEPTED ..."
                        int acc = parsed.Value(GlobalNames.Location_update_accept_type);

                        sb.Append("MS request for registration");
                        if (acc == 0) sb.Append("/authentication ACCEPTED");
                        else sb.Append(" ACCEPTED");

                        if (ssi > 0) { sb.Append(" for SSI: "); sb.Append(ssi); }
                        if (gssi > 0) { sb.Append(" GSSI: "); sb.Append(gssi); }

                        if (cckId > 0) { sb.Append(" - CCK_identifier: "); sb.Append(cckId); }

                        int lut = parsed.Value(GlobalNames.Location_update_type);
                        if (lut >= 0)
                        {
                            string lutText = LocationUpdateTypeToString(lut);
                            if (!string.IsNullOrEmpty(lutText))
                            {
                                sb.Append(" - ");
                                sb.Append(lutText);
                            }
                        }
                        break;
                    }

                    default:
                    {
                        // Fallback: keep readable while including known fields
                        sb.Append("MM ");
                        sb.Append(mmType.ToString());

                        AppendIfPresent(sb, parsed, GlobalNames.Otar_sub_type, "otar_sub");
                        AppendIfPresent(sb, parsed, GlobalNames.Authentication_sub_type, "auth_sub");
                        AppendIfPresent(sb, parsed, GlobalNames.Authentication_status, "auth_status");
                        AppendIfPresent(sb, parsed, GlobalNames.SSI, "ssi");
                        AppendIfPresent(sb, parsed, GlobalNames.GSSI, "gssi");
                        AppendIfPresent(sb, parsed, GlobalNames.MM_SSI, "mm_ssi");
                        AppendIfPresent(sb, parsed, GlobalNames.MM_vGSSI, "vgssi");
                        AppendIfPresent(sb, parsed, GlobalNames.Location_update_type, "lu_type");
                        AppendIfPresent(sb, parsed, GlobalNames.Location_update_accept_type, "lu_acc");
                        AppendIfPresent(sb, parsed, GlobalNames.Reject_cause, "rej");
                        AppendIfPresent(sb, parsed, GlobalNames.Not_supported_sub_PDU_type, "notsup");
                        AppendIfPresent(sb, parsed, GlobalNames.Cipher_control, "cc");
                        AppendIfPresent(sb, parsed, GlobalNames.Group_identity_attach_detach_mode, "gi_mode");
                        AppendIfPresent(sb, parsed, GlobalNames.Group_identity_accept_reject, "gi_acc");
                        break;
                    }
                }

                // Always include raw MM payload so you never miss vendor-specific/unknown fields.
                sb.Append("  raw=");
                sb.Append(BitsToHex(channelData.Ptr, bitOffset, bitLength));

                new TextFile().Write(sb.ToString(), DefaultPath);
            }
            catch
            {
                // ignore logging failures
            }
        }

        private static string AuthenticationStatusToString(int status)
        {
            // Best-effort: many networks use 0 for success/no auth in progress
            if (status < 0) return "Authentication status unknown";
            if (status == 0) return "Authentication successful or no authentication currently in progress";
            return "Authentication status " + status.ToString();
        }

        private static string LocationUpdateTypeToString(int t)
        {
            // Best-effort naming (values can vary by implementation)
            switch (t)
            {
                case 0: return "Normal location updating";
                case 1: return "Roaming location updating";
                case 2: return "Periodic location updating";
                default: return "Location update type " + t.ToString();
            }
        }

        private static void AppendIfPresent(StringBuilder sb, ReceivedData data, GlobalNames name, string label)
        {
            int v = data.Value(name);
            if (v >= 0)
            {
                sb.Append(' ');
                sb.Append(label);
                sb.Append('=');
                sb.Append(v);
            }
        }

        private static string BitsToHex(byte* ptr, int bitOffset, int bitLength)
        {
            if (bitLength <= 0) return string.Empty;

            int byteLen = (bitLength + 7) / 8;
            byte[] bytes = new byte[byteLen];

            for (int i = 0; i < bitLength; i++)
            {
                int bit = ptr[bitOffset + i] & 0x1;
                int byteIndex = i / 8;
                int bitInByte = 7 - (i % 8); // MSB-first
                bytes[byteIndex] |= (byte)(bit << bitInByte);
            }

            var sb = new StringBuilder(byteLen * 2);
            for (int i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToString("X2"));
            return sb.ToString();
        }
    }

    // --------------------------------------------------------------------
    // Fallback enums (REMOVE if you already have them elsewhere in project)
    // --------------------------------------------------------------------

    internal enum D_AuthenticationPduSubType
    {
        Demand = 0,   // observed in your log as auth_sub=0
        Reply  = 1,
        Result = 2,   // observed in your log as auth_sub=2 (success/no auth)
        Reject = 3
    }
}
