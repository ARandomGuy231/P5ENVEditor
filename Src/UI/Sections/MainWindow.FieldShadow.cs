using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayFieldShadowParams()
        {
            SetNumberBox(shadowDepthRangeValue, (decimal)EnvFunctions.loadedENVParams.fieldShadowSection.fieldShadowFarClip);
            SetNumberBox(shadowDiffBrightnessValue, (decimal)EnvFunctions.loadedENVParams.fieldShadowSection.ambientShadowBrightness);
            SetNumberBox(shadowAmbBrightnessValue, (decimal)EnvFunctions.loadedENVParams.fieldShadowSection.fieldShadowBrightness);
            SetNumberBox(shadowBiasValue, (decimal)EnvFunctions.loadedENVParams.fieldShadowSection.field29C);
            SetNumberBox(shadowCascadeValue, (decimal)EnvFunctions.loadedENVParams.fieldShadowSection.fieldShadowNearClip);

            SetNumberBox(shadowUnkValueField294, (decimal)EnvFunctions.loadedENVParams.fieldShadowSection.field294);
            SetNumberBox(shadowUnkValueField2A0, EnvFunctions.loadedENVParams.fieldShadowSection.field2A0);
            shadowUnkBoxField2AC.CheckState = (CheckState)EnvFunctions.loadedENVParams.fieldShadowSection.field2AC;
            shadowUnkBoxField2AD.CheckState = (CheckState)EnvFunctions.loadedENVParams.fieldShadowSection.field2AD;
            shadowUnkBoxField2AE.CheckState = (CheckState)EnvFunctions.loadedENVParams.fieldShadowSection.field2AE;
            shadowUnkBoxField2AF.CheckState = (CheckState)EnvFunctions.loadedENVParams.fieldShadowSection.field2AF;

            if (EnvFunctions.loadedENVHeader.gfsVersion >= 0x1105100)
            {
                shadowColorTable.Enabled = true;
                shadowColorValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldShadowSection.shadowColorRed);
                shadowColorValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldShadowSection.shadowColorGreen);
                shadowColorValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldShadowSection.shadowColorBlue);
                shadowColorValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldShadowSection.shadowColorAlpha);
            }
            else
            {
                shadowColorTable.Enabled = false;
                shadowColorValueR.Value = shadowColorValueR.Minimum;
                shadowColorValueG.Value = shadowColorValueG.Minimum;
                shadowColorValueB.Value = shadowColorValueB.Minimum;
                shadowColorValueA.Value = shadowColorValueA.Maximum;
            }
        }

        private FieldShadowSection CreateFieldShadowSection()
        {
            var newFieldShadowSection = EnvFunctions.loadedENVParams.fieldShadowSection;

            newFieldShadowSection.fieldShadowFarClip = CheckNumberBox(shadowDepthRangeValue, EnvFunctions.loadedENVParams.fieldShadowSection.fieldShadowFarClip);
            newFieldShadowSection.ambientShadowBrightness = CheckNumberBox(shadowDiffBrightnessValue, EnvFunctions.loadedENVParams.fieldShadowSection.ambientShadowBrightness);
            newFieldShadowSection.fieldShadowBrightness = CheckNumberBox(shadowAmbBrightnessValue, EnvFunctions.loadedENVParams.fieldShadowSection.fieldShadowBrightness);
            newFieldShadowSection.field29C = CheckNumberBox(shadowBiasValue, EnvFunctions.loadedENVParams.fieldShadowSection.field29C);
            newFieldShadowSection.fieldShadowNearClip = CheckNumberBox(shadowCascadeValue, EnvFunctions.loadedENVParams.fieldShadowSection.fieldShadowNearClip);

            newFieldShadowSection.field294 = CheckNumberBox(shadowUnkValueField294, EnvFunctions.loadedENVParams.fieldShadowSection.field294);
            newFieldShadowSection.field2A0 = CheckNumberBox(shadowUnkValueField2A0, EnvFunctions.loadedENVParams.fieldShadowSection.field2A0);
            newFieldShadowSection.field2AC = (byte)shadowUnkBoxField2AC.CheckState;
            newFieldShadowSection.field2AD = (byte)shadowUnkBoxField2AD.CheckState;
            newFieldShadowSection.field2AE = (byte)shadowUnkBoxField2AE.CheckState;
            newFieldShadowSection.field2AF = (byte)shadowUnkBoxField2AF.CheckState;

            newFieldShadowSection.shadowColorRed = (float)shadowColorValueR.Value / 255f;
            newFieldShadowSection.shadowColorGreen = (float)shadowColorValueG.Value / 255f;
            newFieldShadowSection.shadowColorBlue = (float)shadowColorValueB.Value / 255f;
            newFieldShadowSection.shadowColorAlpha = (float)shadowColorValueA.Value / 255f;

            return newFieldShadowSection;
        }

        private void UpdateShadowColorSwatch()
        {
            shadowColorSwatch.BackColor = Color.FromArgb((int)shadowColorValueR.Value, (int)shadowColorValueG.Value, (int)shadowColorValueB.Value);
        }

        private void UpdateShadowHex()
        {
            shadowColorHex.Text = $"#{shadowColorSwatch.BackColor.R:X2}{shadowColorSwatch.BackColor.G:X2}{shadowColorSwatch.BackColor.B:X2}";
        }

        private void shadowColorSliderR_Scroll(object sender, EventArgs e)
        {
            shadowColorValueR.Value = shadowColorSliderR.Value;
        }

        private void shadowColorValueR_ValueChanged(object sender, EventArgs e)
        {
            shadowColorSliderR.Value = (int)shadowColorValueR.Value;
            UpdateShadowColorSwatch();
            UpdateShadowHex();
        }

        private void shadowColorSliderG_Scroll(object sender, EventArgs e)
        {
            shadowColorValueG.Value = shadowColorSliderG.Value;
        }

        private void shadowColorValueG_ValueChanged(object sender, EventArgs e)
        {
            shadowColorSliderG.Value = (int)shadowColorValueG.Value;
            UpdateShadowColorSwatch();
            UpdateShadowHex();
        }

        private void shadowColorSliderB_Scroll(object sender, EventArgs e)
        {
            shadowColorValueB.Value = shadowColorSliderB.Value;
        }

        private void shadowColorValueB_ValueChanged(object sender, EventArgs e)
        {
            shadowColorSliderB.Value = (int)shadowColorValueB.Value;
            UpdateShadowColorSwatch();
            UpdateShadowHex();
        }

        private void shadowColorSliderA_Scroll(object sender, EventArgs e)
        {
            shadowColorValueA.Value = shadowColorSliderA.Value;
        }

        private void shadowColorValueA_ValueChanged(object sender, EventArgs e)
        {
            shadowColorSliderA.Value = (int)shadowColorValueA.Value;
        }

        private void shadowColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(shadowColorHex, shadowColorValueR, shadowColorValueG, shadowColorValueB);
        }
    }
}
