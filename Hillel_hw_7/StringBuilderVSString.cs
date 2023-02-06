using System.Text;

namespace Hillel_hw_7
{
    public class StringBuilderVSString
    {
        public static string StringPlusStringPlus_50rows(List<string> strList)
        {
            string rezult = strList[0] + strList[1] + strList[2] + strList[3] + strList[4] +
                strList[5] + strList[6] + strList[7] + strList[8] + strList[9] +
                strList[10] + strList[11] + strList[12] + strList[13] + strList[14] +
                strList[15] + strList[16] + strList[17] + strList[18] + strList[19] +
                strList[20] + strList[21] + strList[22] + strList[23] + strList[24] +
                strList[25] + strList[26] + strList[27] + strList[28] + strList[29] +
                strList[30] + strList[31] + strList[32] + strList[33] + strList[34] +
                strList[35] + strList[36] + strList[37] + strList[38] + strList[39] +
                strList[40] + strList[41] + strList[42] + strList[43] + strList[44] +
                strList[45] + strList[46] + strList[47] + strList[48] + strList[49];
            return rezult;
        }

        public static string StringPlusStringPlus_100rows(List<string> strList)
        {
            string rezult = strList[0] + strList[1] + strList[2] + strList[3] + strList[4] +
                strList[5] + strList[6] + strList[7] + strList[8] + strList[9] +
                strList[10] + strList[11] + strList[12] + strList[13] + strList[14] +
                strList[15] + strList[16] + strList[17] + strList[18] + strList[19] +
                strList[20] + strList[21] + strList[22] + strList[23] + strList[24] +
                strList[25] + strList[26] + strList[27] + strList[28] + strList[29] +
                strList[30] + strList[31] + strList[32] + strList[33] + strList[34] +
                strList[35] + strList[36] + strList[37] + strList[38] + strList[39] +
                strList[40] + strList[41] + strList[42] + strList[43] + strList[44] +
                strList[45] + strList[46] + strList[47] + strList[48] + strList[49] +
                strList[50] + strList[51] + strList[52] + strList[53] + strList[54] +
                strList[55] + strList[56] + strList[57] + strList[58] + strList[59] +
                strList[60] + strList[61] + strList[62] + strList[63] + strList[64] +
                strList[65] + strList[66] + strList[67] + strList[68] + strList[69] +
                strList[70] + strList[71] + strList[72] + strList[73] + strList[74] +
                strList[75] + strList[76] + strList[77] + strList[78] + strList[79] +
                strList[80] + strList[81] + strList[82] + strList[83] + strList[84] +
                strList[85] + strList[86] + strList[87] + strList[88] + strList[89] +
                strList[90] + strList[91] + strList[92] + strList[93] + strList[94] +
                strList[95] + strList[96] + strList[97] + strList[98] + strList[99];
            return rezult;
        }

        public static string StringPlusInCycle(List<string> strList)
        {
            string rezult = "";
            for (int i = 0; i < strList.Count; i++)
            {
                rezult += strList[i];
            }
            return rezult;
        }

        public static string StringBuilderAppendInCycle(List<string> strList)
        {
            StringBuilder stringBuilder= new StringBuilder();
            for(int i = 0; i < strList.Count;i++)
            {
                stringBuilder.Append(strList[i]);
            }
            return stringBuilder.ToString();
        }

        public static string StringContactListToArray (List<string> strList)
        {
            return string.Concat(strList.ToArray());
        }

        public static string StringJoinListToArray(List<string> strList)
        {
            return string.Join("", strList.ToArray());
        }

    }
}