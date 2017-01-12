using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.WebUtility {
    public class CardHelper {

        public static String GetCardState( int nstate ) {
            String strGreen="<span style=\"color:green;\">" + Res.GetValue("CARD_STATE_0") + "</span>";
            String strRed="<span style=\"color:red;\">" + Res.GetValue("CARD_STATE_1") + "</span>";
            return nstate == 0 ? strGreen : strRed;            
        }

        public static String GetCardState2( int nstate ) { //for out file
            return nstate == 0 ? Res.GetValue("CARD_STATE_0") : Res.GetValue("CARD_STATE_1");
        }

        /// <summary>
        /// Gets the card unit.
        /// </summary>
        /// <param name="nCardType">Type of the n card.</param>
        /// <returns>INFO_CARD_VALUE,INFO_CARD_VALUE_MONTH</returns>
        public static String GetCardUnit( Int32 nCardType ) {
            if (nCardType == 0)
                return Res.GetValue("INFO_CARD_VALUE");
            else if (nCardType == 1)
                return Res.GetValue("INFO_CARD_VALUE_MONTH");
            else
                return String.Empty;
        }


    }
}
