using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BetterOOF.Data
{
    public class OOFModel
    {

        public OOFModel()
        {
            this.DateOfReturn = DateOnly.FromDateTime(System.DateTime.Now.AddDays(1));
            this.StandInInformation = "My dear coworker, +99 99 99 99, MyDearCoworker@mycompany.com";
            this.ResultText = string.Empty;
            this.ConvertEnglish = true;
            this.ConvertGerman = true;
            this.ConvertFrench = false;
        }
        public DateOnly DateOfReturn { get; set; }
        [AllowNull]
        public string StandInInformation { get; set; }

        public bool NoStandIn { get; set; }

        public bool ConvertEnglish;
        public bool ConvertGerman;
        public bool ConvertFrench;

        public string ResultText { get; set; }

        private void ChangeCultureForTextGeneration(string StrCultureInfo)
        {
            CultureInfo cultureInfo = new CultureInfo(StrCultureInfo, false);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        }

        private string GermanText()
        {
            this.ChangeCultureForTextGeneration("de-DE");
            string strGerman = "Sehr geehrte Damen und Herren," + System.Environment.NewLine + String.Format("Ich bin abwesend. Am {0} bin ich wieder verfügbar.", this.DateOfReturn.ToLongDateString()) + System.Environment.NewLine;
            if (!this.NoStandIn)
            {
                strGerman += String.Format("In meiner Abwesenheit vertritt mich: {0}", this.StandInInformation) + System.Environment.NewLine;
            }
            else
            {
                strGerman += String.Format("Ich habe keine Vertretung.");
            }
            return strGerman;
        }

        private string EnglishText()
        {
            this.ChangeCultureForTextGeneration("en-US");
            string strEnglish = "Ladies and Gentlemen, " + System.Environment.NewLine + String.Format("I am out of office. I will be back on {0}", this.DateOfReturn.ToLongDateString()) + System.Environment.NewLine;
            if (!this.NoStandIn)
            {
                strEnglish += String.Format("My stand in is: {0}", this.StandInInformation) + System.Environment.NewLine;
            }
            else
            {
                strEnglish += "I do not have a stand-in.";
            }

            return strEnglish; 
        }

        private string FrenchText()
        {
            this.ChangeCultureForTextGeneration("fr-FR");
            string strFrench = "Sehr geehrte Damen und Herren," + System.Environment.NewLine + String.Format("Ich bin abwesend. Am {0} bin ich wieder verfügbar.", this.DateOfReturn.ToLongDateString()) + System.Environment.NewLine;
            if (!this.NoStandIn)
            {
                strFrench += String.Format("In meiner Abwesenheit vertritt mich: {0}", this.StandInInformation) + System.Environment.NewLine;
            }
            else
            {
                strFrench += String.Format("Ich habe keine Vertretung.");
            }
            return strFrench;
        }

        public void Convert()
        {
            string strAdvertisingBlock = System.Environment.NewLine + "------" + System.Environment.NewLine + "Made with betteroof.com" + System.Environment.NewLine + "------";

            string strLanguageSeperator = System.Environment.NewLine + "------" + System.Environment.NewLine + System.Environment.NewLine;

            int iLanguageCounter = 0;

            string restultString = string.Empty;
            if (this.ConvertEnglish)
            {
                iLanguageCounter++;
                restultString += EnglishText();
            }

            if (this.ConvertGerman)
            {
                if (iLanguageCounter != 0)
                {
                    restultString += strLanguageSeperator;
                }
                iLanguageCounter++;
                restultString += GermanText();
            }

            if (this.ConvertFrench)
            {
                if (iLanguageCounter != 0)
                {
                    restultString += strLanguageSeperator;
                }
                iLanguageCounter++;
                restultString += FrenchText();
            }

            restultString += strAdvertisingBlock;
            
            this.ResultText = restultString;
        }

    }
}
