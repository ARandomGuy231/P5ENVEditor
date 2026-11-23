using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayLightingParams()
        {
            enableGraphicOutputBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.enableGraphicalOutput;
            enableToneMapBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.enableToneMap;
            enableStarGlareBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.enableStarGlare;

            if (EnvFunctions.loadedENVHeader.gfsVersion >= 0x1105100)
            {
                DisableCheckBox(enableAdaptedLumBox);
                DisableNumberBox(bloomThresholdValue);
                DisableNumberBox(bloomStrengthValue);
                DisableNumberBox(starGlareStrengthValue);
                DisableNumberBox(bloomBrightnessValue);
                DisableNumberBox(starGlareScaleValue);

                foreach (NumericUpDown box in royalLightingSettingsTable.Controls.OfType<NumericUpDown>())
                {
                    box.Enabled = true;
                }

                foreach (CheckBox box in royalLightingSettingsTable.Controls.OfType<CheckBox>())
                {
                    box.Enabled = true;
                }

                lightingUnkBoxField1CC.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.field1CC;
                lightingUnkBoxField1CD.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.field1CD;
                lightingUnkBoxField1CE.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.field1CE;
                lightingUnkBoxField1CF.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.field1CF;
                SetNumberBox(lightingUnkValueField1D0, EnvFunctions.loadedENVParams.lightingSection.field1D0);
                SetNumberBox(bloomAmountValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.bloomAmount);
                SetNumberBox(bloomDetailValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.bloomDetail);
                SetNumberBox(bloomWhiteLevelValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.bloomWhiteLevel);
                SetNumberBox(bloomDarkLevelValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.bloomDarkLevel);
                SetNumberBox(glareSensitivityValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.glareSensitivity);
                SetNumberBox(sceneWhiteLevelValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.sceneWhiteLevels);
                SetNumberBox(sceneDarkLevelValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.sceneDarkLevels);
                SetNumberBox(lightingUnkValueField1F0, (decimal)EnvFunctions.loadedENVParams.lightingSection.field1F0);
                SetNumberBox(lightingUnkValueField1F4, (decimal)EnvFunctions.loadedENVParams.lightingSection.field1F4);
                SetNumberBox(lightingUnkValueField1F8, (decimal)EnvFunctions.loadedENVParams.lightingSection.field1F8);
                SetNumberBox(lightingUnkValueField1FC, EnvFunctions.loadedENVParams.lightingSection.field1FC);
                SetNumberBox(lightingUnkValueField200, (decimal)EnvFunctions.loadedENVParams.lightingSection.field200);
                SetNumberBox(lightingUnkValueField204, (decimal)EnvFunctions.loadedENVParams.lightingSection.field204);
                SetNumberBox(lightingUnkValueField208, EnvFunctions.loadedENVParams.lightingSection.field208);
                SetNumberBox(lightingUnkValueField20C, EnvFunctions.loadedENVParams.lightingSection.field20C);
                SetNumberBox(lightingUnkValueField210, (decimal)EnvFunctions.loadedENVParams.lightingSection.field210);
                SetNumberBox(lightingUnkValueField214, (decimal)EnvFunctions.loadedENVParams.lightingSection.field214);
                SetNumberBox(redColorBoostValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.redColorBoost);
                SetNumberBox(greenColorBoostValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.greenColorBoost);
                SetNumberBox(blueColorBoostValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.blueColorBoost);
                SetNumberBox(lightingUnkValueField224, (decimal)EnvFunctions.loadedENVParams.lightingSection.field224);
                SetNumberBox(lightingUnkValueField228, (decimal)EnvFunctions.loadedENVParams.lightingSection.field228);
                SetNumberBox(lightingUnkValueField22C, (decimal)EnvFunctions.loadedENVParams.lightingSection.field22C);
                SetNumberBox(lightingUnkValueField230, (decimal)EnvFunctions.loadedENVParams.lightingSection.field230);
                SetNumberBox(lightingUnkValueField234, (decimal)EnvFunctions.loadedENVParams.lightingSection.field234);
                SetNumberBox(lightingUnkValueField238, (decimal)EnvFunctions.loadedENVParams.lightingSection.field238);
                SetNumberBox(lightingUnkValueField23C, (decimal)EnvFunctions.loadedENVParams.lightingSection.field23C);
            }
            else
            {
                foreach (NumericUpDown box in royalLightingSettingsTable.Controls.OfType<NumericUpDown>())
                {
                    DisableNumberBox(box);
                }

                foreach (CheckBox box in royalLightingSettingsTable.Controls.OfType<CheckBox>())
                {
                    DisableCheckBox(box);
                }
                
                enableAdaptedLumBox.Enabled = true;
                bloomThresholdValue.Enabled = true;
                bloomStrengthValue.Enabled = true;
                starGlareStrengthValue.Enabled = true;
                bloomBrightnessValue.Enabled = true;
                starGlareScaleValue.Enabled = true;

                enableAdaptedLumBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.enableAdaptedLumAuto;
                SetNumberBox(bloomThresholdValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.middleGray);
                SetNumberBox(bloomStrengthValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.bloomScale);
                SetNumberBox(starGlareStrengthValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.adaptedLum);
                SetNumberBox(bloomBrightnessValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.elapsedTime);
                SetNumberBox(starGlareScaleValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareScale);
            }

            SetNumberBox(starGlareLinesValue, EnvFunctions.loadedENVParams.lightingSection.starGlareLines);
            SetNumberBox(starGlareLengthValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareLength);
            SetNumberBox(starGlareTiltValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareSI);
            SetNumberBox(starGlareCAValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareChromaticAberration);
        }

        private LightingSection CreateLightingSection()
        {
            var newLightingSection = EnvFunctions.loadedENVParams.lightingSection;

            newLightingSection.enableGraphicalOutput = (byte)enableGraphicOutputBox.CheckState;
            newLightingSection.enableToneMap = (byte)enableToneMapBox.CheckState;
            newLightingSection.enableStarGlare = (byte)enableStarGlareBox.CheckState;

            newLightingSection.field1CC = CheckToggleBox(lightingUnkBoxField1CC, newLightingSection.field1CC);
            newLightingSection.field1CD = CheckToggleBox(lightingUnkBoxField1CD, newLightingSection.field1CD);
            newLightingSection.field1CE = CheckToggleBox(lightingUnkBoxField1CE, newLightingSection.field1CE);
            newLightingSection.field1CF = CheckToggleBox(lightingUnkBoxField1CF, newLightingSection.field1CF);
            newLightingSection.field1D0 = CheckNumberBox(lightingUnkValueField1D0, newLightingSection.field1D0);
            newLightingSection.bloomAmount = CheckNumberBox(bloomAmountValue, newLightingSection.bloomAmount);
            newLightingSection.bloomDetail = CheckNumberBox(bloomDetailValue, newLightingSection.bloomDetail);
            newLightingSection.bloomWhiteLevel = CheckNumberBox(bloomWhiteLevelValue, newLightingSection.bloomWhiteLevel);
            newLightingSection.bloomDarkLevel = CheckNumberBox(bloomDarkLevelValue, newLightingSection.bloomDarkLevel);
            newLightingSection.glareSensitivity = CheckNumberBox(glareSensitivityValue, newLightingSection.glareSensitivity);
            newLightingSection.sceneWhiteLevels = CheckNumberBox(sceneWhiteLevelValue, newLightingSection.sceneWhiteLevels);
            newLightingSection.sceneDarkLevels = CheckNumberBox(sceneDarkLevelValue, newLightingSection.sceneDarkLevels);
            newLightingSection.field1F0 = CheckNumberBox(lightingUnkValueField1F0, newLightingSection.field1F0);
            newLightingSection.field1F4 = CheckNumberBox(lightingUnkValueField1F4, newLightingSection.field1F4);
            newLightingSection.field1F8 = CheckNumberBox(lightingUnkValueField1F8, newLightingSection.field1F8);
            newLightingSection.field1F4 = CheckNumberBox(lightingUnkValueField1FC, newLightingSection.field1FC);
            newLightingSection.field200 = CheckNumberBox(lightingUnkValueField200, newLightingSection.field200);
            newLightingSection.field204 = CheckNumberBox(lightingUnkValueField204, newLightingSection.field204);
            newLightingSection.field208 = CheckNumberBox(lightingUnkValueField208, newLightingSection.field208);
            newLightingSection.field20C = CheckNumberBox(lightingUnkValueField20C, newLightingSection.field20C);
            newLightingSection.field210 = CheckNumberBox(lightingUnkValueField210, newLightingSection.field210);
            newLightingSection.field214 = CheckNumberBox(lightingUnkValueField214, newLightingSection.field214);
            newLightingSection.redColorBoost = CheckNumberBox(redColorBoostValue, newLightingSection.redColorBoost);
            newLightingSection.greenColorBoost = CheckNumberBox(greenColorBoostValue, newLightingSection.greenColorBoost);
            newLightingSection.blueColorBoost = CheckNumberBox(blueColorBoostValue, newLightingSection.blueColorBoost);
            newLightingSection.field224 = CheckNumberBox(lightingUnkValueField224, newLightingSection.field224);
            newLightingSection.field228 = CheckNumberBox(lightingUnkValueField228, newLightingSection.field228);
            newLightingSection.field22C = CheckNumberBox(lightingUnkValueField22C, newLightingSection.field22C);
            newLightingSection.field230 = CheckNumberBox(lightingUnkValueField230, newLightingSection.field230);
            newLightingSection.field234 = CheckNumberBox(lightingUnkValueField234, newLightingSection.field234);
            newLightingSection.field238 = CheckNumberBox(lightingUnkValueField238, newLightingSection.field238);
            newLightingSection.field23C = CheckNumberBox(lightingUnkValueField23C, newLightingSection.field23C);

            newLightingSection.enableAdaptedLumAuto = CheckToggleBox(enableAdaptedLumBox, newLightingSection.enableAdaptedLumAuto);
            newLightingSection.middleGray = CheckNumberBox(bloomThresholdValue, newLightingSection.middleGray);
            newLightingSection.bloomScale = CheckNumberBox(bloomStrengthValue, newLightingSection.bloomScale);
            newLightingSection.adaptedLum = CheckNumberBox(starGlareStrengthValue, newLightingSection.adaptedLum);
            newLightingSection.elapsedTime = CheckNumberBox(bloomBrightnessValue, newLightingSection.elapsedTime);
            newLightingSection.starGlareScale = CheckNumberBox(starGlareScaleValue, newLightingSection.starGlareScale);

            newLightingSection.starGlareLines = CheckNumberBox(starGlareLinesValue, newLightingSection.starGlareLines);
            newLightingSection.starGlareLength = CheckNumberBox(starGlareLengthValue, newLightingSection.starGlareLength);
            newLightingSection.starGlareSI = CheckNumberBox(starGlareTiltValue, newLightingSection.starGlareSI);
            newLightingSection.starGlareChromaticAberration = CheckNumberBox(starGlareCAValue, newLightingSection.starGlareChromaticAberration);

            return newLightingSection;
        }

        private void starGlareLinesSlider_Scroll(object sender, EventArgs e)
        {
            starGlareLinesValue.Value = starGlareLinesSlider.Value;
        }

        private void starGlareLinesValue_ValueChanged(object sender, EventArgs e)
        {
            starGlareLinesSlider.Value = (int)starGlareLinesValue.Value;
        }
    }
}
