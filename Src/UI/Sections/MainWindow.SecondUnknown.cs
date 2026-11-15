using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplaySecondUnknownParams()
        {
            lightMapColorValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.secondUnknownSection.lightMapR);
            lightMapColorValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.secondUnknownSection.lightMapG);
            lightMapColorValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.secondUnknownSection.lightMapB);
            lightMapColorValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.secondUnknownSection.lightMapA);

            enableCharacterOutlinesBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.secondUnknownSection.enableCharacterOutlines;
            SetNumberBox(characterOutlineRangeValue, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.characterOutlineOpacity);
            SetNumberBox(characterOutlineWidthValue, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.characterOutlineWidth);

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1104940)
            {
                DisableNumberBox(miscUnkValueField27A);
                characterOutlineBrightnessValue.Enabled = true;

                SetNumberBox(characterOutlineBrightnessValue, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.characterOutlineBrightness);
            }
            else
            {
                DisableNumberBox(characterOutlineBrightnessValue);
                miscUnkValueField27A.Enabled = true;

                SetNumberBox(miscUnkValueField27A, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.field27A);
            }

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1104970)
            {
                DisableNumberBox(miscUnkValueField284);
                characterOutlineStartValue.Enabled = true;

                SetNumberBox(characterOutlineStartValue, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.field2F2);

                if (EnvFunctions.loadedENVHeader.gfsVersion != 0x1105020 && EnvFunctions.loadedENVParams.secondUnknownSection.enableCharacterOutlines == 1)
                {
                    characterOutlineEndValue.Enabled = true;
                    refHeightValue.Enabled = true;

                    SetNumberBox(characterOutlineEndValue, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.field2F6);
                    SetNumberBox(refHeightValue, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.reflectionHeight);
                }
                else
                {
                    DisableNumberBox(characterOutlineEndValue);
                    DisableNumberBox(refHeightValue);
                }
            }
            else if (EnvFunctions.loadedENVHeader.gfsVersion == 0x1104970)
            {
                DisableNumberBox(characterOutlineStartValue);
                DisableNumberBox(characterOutlineEndValue);
                DisableNumberBox(refHeightValue);
                miscUnkValueField284.Enabled = true;

                SetNumberBox(miscUnkValueField284, (decimal)EnvFunctions.loadedENVParams.secondUnknownSection.field284);
            }
            else
            {
                DisableNumberBox(characterOutlineStartValue);
                DisableNumberBox(characterOutlineEndValue);
                DisableNumberBox(refHeightValue);
                DisableNumberBox(miscUnkValueField284);
            }
        }

        private SecondUnknownSection CreateSecondUnknownSection()
        {
            var newSecondUnknownSection = EnvFunctions.loadedENVParams.secondUnknownSection;

            newSecondUnknownSection.lightMapR = (float)lightMapColorValueR.Value / 255f;
            newSecondUnknownSection.lightMapG = (float)lightMapColorValueG.Value / 255f;
            newSecondUnknownSection.lightMapB = (float)lightMapColorValueB.Value / 255f;
            newSecondUnknownSection.lightMapA = (float)lightMapColorValueA.Value / 255f;

            newSecondUnknownSection.enableCharacterOutlines = (byte)enableCharacterOutlinesBox.CheckState;
            newSecondUnknownSection.characterOutlineOpacity = CheckNumberBox(characterOutlineRangeValue, newSecondUnknownSection.characterOutlineOpacity);
            newSecondUnknownSection.characterOutlineWidth = CheckNumberBox(characterOutlineWidthValue, newSecondUnknownSection.characterOutlineWidth);

            newSecondUnknownSection.field27A = CheckNumberBox(miscUnkValueField27A, newSecondUnknownSection.field27A);
            newSecondUnknownSection.characterOutlineBrightness = CheckNumberBox(characterOutlineBrightnessValue, newSecondUnknownSection.characterOutlineBrightness);
            newSecondUnknownSection.field2F2 = CheckNumberBox(characterOutlineStartValue, newSecondUnknownSection.field2F2);
            newSecondUnknownSection.field2F6 = CheckNumberBox(characterOutlineEndValue, newSecondUnknownSection.field2F6);
            newSecondUnknownSection.reflectionHeight = CheckNumberBox(refHeightValue, newSecondUnknownSection.reflectionHeight);

            newSecondUnknownSection.field284 = CheckNumberBox(miscUnkValueField284, newSecondUnknownSection.field284);

            return newSecondUnknownSection;
        }

        private void UpdateLightMapSwatch()
        {
            lightMapColorSwatch.BackColor = Color.FromArgb((int)lightMapColorValueR.Value, (int)lightMapColorValueG.Value, (int)lightMapColorValueB.Value);
        }

        private void lightMapColorSliderR_Scroll(object sender, EventArgs e)
        {
            lightMapColorValueR.Value = lightMapColorSliderR.Value;
        }

        private void lightMapColorValueR_ValueChanged(object sender, EventArgs e)
        {
            lightMapColorSliderR.Value = (int)lightMapColorValueR.Value;
            UpdateLightMapSwatch();
        }

        private void lightMapColorSliderG_Scroll(object sender, EventArgs e)
        {
            lightMapColorValueG.Value = lightMapColorSliderG.Value;
        }

        private void lightMapColorValueG_ValueChanged(object sender, EventArgs e)
        {
            lightMapColorSliderG.Value = (int)lightMapColorValueG.Value;
            UpdateLightMapSwatch();
        }

        private void lightMapColorSliderB_Scroll(object sender, EventArgs e)
        {
            lightMapColorValueB.Value = lightMapColorSliderB.Value;
        }

        private void lightMapColorValueB_ValueChanged(object sender, EventArgs e)
        {
            lightMapColorSliderB.Value = (int)lightMapColorValueB.Value;
            UpdateLightMapSwatch();
        }

        private void lightMapColorSliderA_Scroll(object sender, EventArgs e)
        {
            lightMapColorValueA.Value = lightMapColorSliderA.Value;
        }

        private void lightMapColorValueA_ValueChanged(object sender, EventArgs e)
        {
            lightMapColorSliderA.Value = (int)lightMapColorValueA.Value;
        }
    }
}
