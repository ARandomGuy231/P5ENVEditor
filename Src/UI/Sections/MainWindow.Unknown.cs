using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayUnknownParams()
        {
            //diffusion settings shown in lighting tab
            enableDiffusionFilterBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.unknownSection.field1F1;
            SetNumberBox(diffusionFilterBrightnessValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.field1F2);

            if (EnvFunctions.loadedENVHeader.gfsVersion != 0x1104910)
            {
                DisableNumberBox(miscUnkValueField1F6);
                DisableNumberBox(miscUnkValueField1F7);
                DisableNumberBox(miscUnkValueField1F8);
                DisableNumberBox(miscUnkValueField1F9);
                diffusionFilterStrengthValue.Enabled = true;

                SetNumberBox(diffusionFilterStrengthValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.diffFilterStrength);
            }
            else
            {
                DisableNumberBox(diffusionFilterStrengthValue);
                miscUnkValueField1F6.Enabled = true;
                miscUnkValueField1F7.Enabled = true;
                miscUnkValueField1F8.Enabled = true;
                miscUnkValueField1F9.Enabled = true;

                SetNumberBox(miscUnkValueField1F6, EnvFunctions.loadedENVParams.unknownSection.field1F6);
                SetNumberBox(miscUnkValueField1F7, EnvFunctions.loadedENVParams.unknownSection.field1F7);
                SetNumberBox(miscUnkValueField1F8, EnvFunctions.loadedENVParams.unknownSection.field1F8);
                SetNumberBox(miscUnkValueField1F9, EnvFunctions.loadedENVParams.unknownSection.field1F9);
            }

            SetNumberBox(diffusionFilterBrightness2Value, (decimal)EnvFunctions.loadedENVParams.unknownSection.field1FA);

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1105040)
            {
                enableDofBox.Enabled = true;
                dofFocalPlaneValue.Enabled = true;
                dofNearBlurPlaneValue.Enabled = true;
                dofFarBlurPlaneValue.Enabled = true;

                enableDofBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.unknownSection.enableDOF;
                SetNumberBox(dofFocalPlaneValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.dofFocalPlane);
                SetNumberBox(dofNearBlurPlaneValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.dofNearBlurPlane);
                SetNumberBox(dofFarBlurPlaneValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.dofFarBlurPlane);
            }
            else
            {
                DisableCheckBox(enableDofBox);
                DisableNumberBox(dofFocalPlaneValue);
                DisableNumberBox(dofNearBlurPlaneValue);
                DisableNumberBox(dofFarBlurPlaneValue);
            }

            SetNumberBox(dofFarBlurLimitValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.dofFarBlurLimit);
            SetNumberBox(dofBlurScaleValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.dofBlurScale);

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1105000)
            {
                dofGaussTypeBox.Enabled = true;
                dofGaussTypeBox.SelectedIndex = (int)EnvFunctions.loadedENVParams.unknownSection.dofGaussType;
            }
            else
            {
                DisableComboBox(dofGaussTypeBox);
            }

            enableSSAOBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.unknownSection.enableSSAO;
            SetNumberBox(ssaoOccluderRadiusValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.ssaoOccluderRadius);
            SetNumberBox(ssaoFallOffRadiusValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.ssaoFallOffRadius);
            SetNumberBox(ssaoBlurScaleValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.ssaoBlurScale);
            SetNumberBox(ssaoBrightnessValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.ssaoBrightness);
            SetNumberBox(ssaoDepthRangeValue, (decimal)EnvFunctions.loadedENVParams.unknownSection.ssaoDepthRange);
        }

        private UnknownSection CreateUnknownSection()
        {
            var newUnknownSection = EnvFunctions.loadedENVParams.unknownSection;

            //Diffusion filter settings are shown in the lighting tab
            newUnknownSection.field1F1 = (byte)enableDiffusionFilterBox.CheckState;
            newUnknownSection.field1F2 = CheckNumberBox(diffusionFilterBrightnessValue, newUnknownSection.field1F2);
            newUnknownSection.diffFilterStrength = CheckNumberBox(diffusionFilterStrengthValue, newUnknownSection.diffFilterStrength);
            newUnknownSection.field1FA = CheckNumberBox(diffusionFilterBrightness2Value, newUnknownSection.field1FA);

            if (enableDofBox.Enabled)
            {
                newUnknownSection.enableDOF = (byte)enableDofBox.CheckState;
            }

            newUnknownSection.dofFocalPlane = CheckNumberBox(dofFocalPlaneValue, newUnknownSection.dofFocalPlane);
            newUnknownSection.dofNearBlurPlane = CheckNumberBox(dofNearBlurPlaneValue, newUnknownSection.dofNearBlurPlane);
            newUnknownSection.dofFarBlurPlane = CheckNumberBox(dofFarBlurPlaneValue, newUnknownSection.dofFarBlurPlane);

            newUnknownSection.dofFarBlurLimit = CheckNumberBox(dofFarBlurLimitValue, newUnknownSection.dofFarBlurLimit);
            newUnknownSection.dofBlurScale = CheckNumberBox(dofBlurScaleValue, newUnknownSection.dofBlurScale);

            if (dofGaussTypeBox.Enabled)
            {
                newUnknownSection.dofGaussType = (uint)dofGaussTypeBox.SelectedIndex;
            }

            newUnknownSection.enableSSAO = (byte)enableSSAOBox.CheckState;
            newUnknownSection.ssaoOccluderRadius = CheckNumberBox(ssaoOccluderRadiusValue, newUnknownSection.ssaoOccluderRadius);
            newUnknownSection.ssaoFallOffRadius = CheckNumberBox(ssaoFallOffRadiusValue, newUnknownSection.ssaoFallOffRadius);
            newUnknownSection.ssaoBlurScale = CheckNumberBox(ssaoBlurScaleValue, newUnknownSection.ssaoBlurScale);
            newUnknownSection.ssaoBrightness = CheckNumberBox(ssaoBrightnessValue, newUnknownSection.ssaoBrightness);
            newUnknownSection.ssaoDepthRange = CheckNumberBox(ssaoDepthRangeValue, newUnknownSection.ssaoDepthRange);

            return newUnknownSection;
        }
    }
}
