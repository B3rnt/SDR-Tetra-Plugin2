using System;
using System.Text;

namespace SDRSharp.Tetra
{
    unsafe class MmLevel
    {
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

            switch (mmType)
            {
                case MmPduType.D_LOCATION_UPDATE_ACCEPT:
                    offset = Global.ParseParams(channelData, offset, _locationUpdateAcceptRules, result);

                    // IMPORTANT: SDRtetra haalt GSSI uit de "Group identity location accept" extension NA rules_0
                    offset = ParseLocationUpdateAcceptExtensions(channelData, offset, result);
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
                    if (offset + 4 <= channelData.Length)
                    {
                        int sub = TetraUtils.BitsToInt32(channelData.Ptr, offset, 4);
                        result.SetValue(GlobalNames.Otar_sub_type, sub);
                        offset += 4;

                        // best-effort CCK_id early in OTAR
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
                    if (offset + 2 <= channelData.Length)
                    {
                        int sub = TetraUtils.BitsToInt32(channelData.Ptr, offset, 2);
                        result.SetValue(GlobalNames.Authentication_sub_type, sub);
                        offset += 2;

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
                    break;
            }

            MmLogger.LogMmPdu(channelData, mmStart, channelData.Length - mmStart, result);
        }

        /// <summary>
        /// Port of the key idea from SDRtetra Class18:
        /// After Location Update Accept base fields, parse "Group identity location accept" extension
        /// where GSSI is carried.
        /// </summary>
        private static int ParseLocationUpdateAcceptExtensions(LogicChannel channelData, int offset, ReceivedData result)
        {
            try
            {
                // Need at least the first 6 bits: 4b group_identity_location_accept + 2b default_group_attachment_lifetime
                if (offset + 6 > channelData.Length)
                    return offset;

                // 4 bits: Group_identity_location_accept (we don't need to store the value to show GSSI)
                int groupIdentityLocAccept = TetraUtils.BitsToInt32(channelData.Ptr, offset, 4);
                offset += 4;

                // 2 bits: Default_group_attachment_lifetime
                int defaultLifetime = TetraUtils.BitsToInt32(channelData.Ptr, offset, 2);
                offset += 2;

                // SDRtetra parses a list of group identity elements:
                // type(2): 0=GSSI, 1=GSSI+extra24, 2=vGSSI, 3=end
                // We store the LAST seen GSSI from this list into GlobalNames.GSSI as a fallback,
                // but in many captures the "real" displayed GSSI comes from a later 24-bit field (see below).
                while (offset + 2 <= channelData.Length)
                {
                    int t = TetraUtils.BitsToInt32(channelData.Ptr, offset, 2);
                    offset += 2;

                    if (t == 3)
                        break;

                    if (t == 0)
                    {
                        if (offset + 24 > channelData.Length) break;
                        int gssi = TetraUtils.BitsToInt32(channelData.Ptr, offset, 24);
                        offset += 24;

                        // keep as candidate
                        result.SetValue(GlobalNames.GSSI, gssi);
                    }
                    else if (t == 1)
                    {
                        if (offset + 48 > channelData.Length) break;
                        int gssi = TetraUtils.BitsToInt32(channelData.Ptr, offset, 24);
                        offset += 24;

                        // store candidate
                        result.SetValue(GlobalNames.GSSI, gssi);

                        // skip extra 24 bits
                        offset += 24;
                    }
                    else if (t == 2)
                    {
                        if (offset + 24 > channelData.Length) break;
                        int vgssi = TetraUtils.BitsToInt32(channelData.Ptr, offset, 24);
                        offset += 24;

                        result.SetValue(GlobalNames.MM_vGSSI, vgssi);
                    }
                    else
                    {
                        // unknown, stop safely
                        break;
                    }
                }

                // IMPORTANT (matches your capture):
                // After the list end (t==3), there is a 5-bit field and THEN a 24-bit GSSI that SDRtetra displays.
                // This is exactly where your 0x2BA62A sits.
                if (offset + 5 + 24 <= channelData.Length)
                {
                    // skip 5 bits (unknown flags / header)
                    offset += 5;

                    int gssi2 = TetraUtils.BitsToInt32(channelData.Ptr, offset, 24);
                    offset += 24;

                    result.SetValue(GlobalNames.GSSI, gssi2);
                }

                // Best-effort: find 8-bit CCK_id (often 64) on the next byte boundary in the next 64 bits.
                // SDRtetra prints it as CCK_identifier.
                int scanEnd = Math.Min(channelData.Length - 8, offset + 64);
                for (int i = offset; i <= scanEnd; i++)
                {
                    if ((i % 8) != 0) continue; // only byte-aligned
                    int b = TetraUtils.BitsToInt32(channelData.Ptr, i, 8);
                    if (b == 64) // common case seen in SDRtetra logs
                    {
                        result.SetValue(GlobalNames.CCK_id, b);
                        break;
                    }
                }

                return offset;
            }
            catch
            {
                return offset;
            }
        }
    }

    internal static unsafe class MmLogger
    {
        private const string DefaultPath = "mm_messages.log";

        // Remember last auth status like SDRtetra effectively does (so LU accept can print it too)
        private static int _lastAuthStatus = -1;
        private static int _lastAuthSsi = -1;

        public static void LogMmPdu(LogicChannel channelData, int bitOffset, int bitLength, ReceivedData parsed)
        {
            try
            {
                var sb = new StringBuilder(512);
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.Append("  ");

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

                int ssi = parsed.Value(GlobalNames.SSI);
                if (ssi <= 0) ssi = parsed.Value(GlobalNames.MM_SSI);

                int gssi = parsed.Value(GlobalNames.GSSI);
                if (gssi <= 0) gssi = parsed.Value(GlobalNames.MM_vGSSI);

                int cckId = parsed.Value(GlobalNames.CCK_id);

                switch (mmType)
                {
                    case MmPduType.D_AUTHENTICATION:
                    {
                        int sub = parsed.Value(GlobalNames.Authentication_sub_type);
                        int status = parsed.Value(GlobalNames.Authentication_status);

                        if (sub == (int)D_AuthenticationPduSubType.Result || sub == (int)D_AuthenticationPduSubType.Reject)
                        {
                            _lastAuthStatus = status;
                            _lastAuthSsi = ssi;
                        }

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
                            sb.Append(" - ");
                            sb.Append(AuthenticationStatusToString(status));
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
                            sb.Append("MM D_AUTHENTICATION");
                            sb.Append(" auth_sub=");
                            sb.Append(sub);
                            if (ssi > 0) { sb.Append(" SSI: "); sb.Append(ssi); }
                        }
                        break;
                    }

                    case MmPduType.D_LOCATION_UPDATE_ACCEPT:
                    {
                        int acc = parsed.Value(GlobalNames.Location_update_accept_type);

                        sb.Append("MS request for registration");
                        if (acc == 0) sb.Append("/authentication ACCEPTED");
                        else sb.Append(" ACCEPTED");

                        if (ssi > 0) { sb.Append(" for SSI: "); sb.Append(ssi); }
                        if (gssi > 0) { sb.Append(" GSSI: "); sb.Append(gssi); }

                        // Add last auth status if we have it (mimic SDRtetra line)
                        if (_lastAuthStatus >= 0 && (_lastAuthSsi <= 0 || _lastAuthSsi == ssi))
                        {
                            sb.Append(" - ");
                            sb.Append(AuthenticationStatusToString(_lastAuthStatus));
                        }

                        if (cckId > 0)
                        {
                            sb.Append(" - CCK_identifier: ");
                            sb.Append(cckId);
                        }

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
                        sb.Append("MM ");
                        sb.Append(mmType.ToString());

                        AppendIfPresent(sb, parsed, GlobalNames.Otar_sub_type, "otar_sub");
                        AppendIfPresent(sb, parsed, GlobalNames.Authentication_sub_type, "auth_sub");
                        AppendIfPresent(sb, parsed, GlobalNames.Authentication_status, "auth_status");
                        AppendIfPresent(sb, parsed, GlobalNames.SSI, "ssi");
                        AppendIfPresent(sb, parsed, GlobalNames.GSSI, "gssi");
                        AppendIfPresent(sb, parsed, GlobalNames.MM_SSI, "mm_ssi");
                        AppendIfPresent(sb, parsed, GlobalNames.MM_vGSSI, "vgssi");
                        AppendIfPresent(sb, parsed, GlobalNames.CCK_id, "cck");
                        break;
                    }
                }

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
            // SDRtetra prints "Authentication successful..." for your statuses (62/48/55 etc)
            // so we treat common seen values as success.
            if (status < 0) return "Authentication status unknown";
            if (status == 0 || status == 62 || status == 48 || status == 55)
                return "Authentication successful or no authentication currently in progress";

            return "Authentication status " + status.ToString();
        }

        private static string LocationUpdateTypeToString(int t)
        {
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
}
