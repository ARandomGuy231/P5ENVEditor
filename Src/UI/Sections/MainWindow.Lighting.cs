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
            enableAdaptedLumBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.enableAdaptedLumAuto;
            SetNumberBox(bloomThresholdValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.middleGray);
            SetNumberBox(bloomStrengthValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.bloomScale);
            SetNumberBox(bloomBrightnessValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.elapsedTime);

            enableStarGlareBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.lightingSection.enableStarGlare;
            SetNumberBox(starGlareLinesValue, EnvFunctions.loadedENVParams.lightingSection.starGlareLines);
            SetNumberBox(starGlareStrengthValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.adaptedLum);
            SetNumberBox(starGlareLengthValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareLength);
            SetNumberBox(starGlareTiltValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareSI);
            SetNumberBox(starGlareScaleValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareScale);
            SetNumberBox(starGlareCAValue, (decimal)EnvFunctions.loadedENVParams.lightingSection.starGlareChromaticAberration);
        }

        private LightingSection CreateLightingSection()
        {
            var newLightingSection = EnvFunctions.loadedENVParams.lightingSection;

            newLightingSection.enableGraphicalOutput = (byte)enableGraphicOutputBox.CheckState;
            newLightingSection.enableToneMap = (byte)enableToneMapBox.CheckState;
            newLightingSection.enableAdaptedLumAuto = (byte)enableAdaptedLumBox.CheckState;
            newLightingSection.middleGray = CheckNumberBox(bloomThresholdValue, newLightingSection.middleGray);
            newLightingSection.bloomScale = CheckNumberBox(bloomStrengthValue, newLightingSection.bloomScale);
            newLightingSection.elapsedTime = CheckNumberBox(bloomBrightnessValue, newLightingSection.elapsedTime);

            newLightingSection.enableStarGlare = (byte)enableStarGlareBox.CheckState;
            newLightingSection.starGlareLines = CheckNumberBox(starGlareLinesValue, newLightingSection.starGlareLines);
            newLightingSection.adaptedLum = CheckNumberBox(starGlareStrengthValue, newLightingSection.adaptedLum);
            newLightingSection.starGlareLength = CheckNumberBox(starGlareLengthValue, newLightingSection.starGlareLength);
            newLightingSection.starGlareSI = CheckNumberBox(starGlareTiltValue, newLightingSection.starGlareSI);
            newLightingSection.starGlareScale = CheckNumberBox(starGlareScaleValue, newLightingSection.starGlareScale);
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
