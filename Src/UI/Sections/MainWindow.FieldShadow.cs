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

            return newFieldShadowSection;
        }
    }
}
