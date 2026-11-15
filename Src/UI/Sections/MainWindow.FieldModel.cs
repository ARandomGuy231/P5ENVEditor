using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayFieldModelParams()
        {
            fldAmbValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelAmbientR);
            fldAmbValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelAmbientG);
            fldAmbValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelAmbientB);
            fldAmbValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelAmbientA);

            fldDiffValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelDiffuseR);
            fldDiffValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelDiffuseG);
            fldDiffValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelDiffuseB);
            fldDiffValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelDiffuseA);

            fldSpecValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelSpecularR);
            fldSpecValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelSpecularG);
            fldSpecValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelSpecularB);
            fldSpecValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelSpecularA);

            fldEmissiveValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelEmissiveR);
            fldEmissiveValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelEmissiveG);
            fldEmissiveValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelEmissiveB);
            fldEmissiveValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.fieldModelSection.fieldModelEmissiveA);

            SetNumberBox(fldLightDirValueX, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.fieldModelLightX);
            SetNumberBox(fldLightDirValueY, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.fieldModelLightY);
            SetNumberBox(fldLightDirValueZ, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.fieldModelLightZ);

            SetNumberBox(fldUnkValueField52, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.field52);
            SetNumberBox(fldUnkValueField56, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.field56);
            SetNumberBox(fldUnkValueField5A, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.field5A);
            SetNumberBox(fldUnkValueField5E, (decimal)EnvFunctions.loadedENVParams.fieldModelSection.field5E);
        }

        private FieldModelSection CreateFieldModelSection()
        {
            var newFieldModelSection = EnvFunctions.loadedENVParams.fieldModelSection;

            newFieldModelSection.fieldModelAmbientR = (float)fldAmbValueR.Value / 255f;
            newFieldModelSection.fieldModelAmbientG = (float)fldAmbValueG.Value / 255f;
            newFieldModelSection.fieldModelAmbientB = (float)fldAmbValueB.Value / 255f;
            newFieldModelSection.fieldModelAmbientA = (float)fldAmbValueA.Value / 255f;

            newFieldModelSection.fieldModelDiffuseR = (float)fldDiffValueR.Value / 255f;
            newFieldModelSection.fieldModelDiffuseG = (float)fldDiffValueG.Value / 255f;
            newFieldModelSection.fieldModelDiffuseB = (float)fldDiffValueB.Value / 255f;
            newFieldModelSection.fieldModelDiffuseA = (float)fldDiffValueA.Value / 255f;

            newFieldModelSection.fieldModelSpecularR = (float)fldSpecValueR.Value / 255f;
            newFieldModelSection.fieldModelSpecularG = (float)fldSpecValueG.Value / 255f;
            newFieldModelSection.fieldModelSpecularB = (float)fldSpecValueB.Value / 255f;
            newFieldModelSection.fieldModelSpecularA = (float)fldSpecValueA.Value / 255f;

            newFieldModelSection.fieldModelEmissiveR = (float)fldEmissiveValueR.Value / 255f;
            newFieldModelSection.fieldModelEmissiveG = (float)fldEmissiveValueG.Value / 255f;
            newFieldModelSection.fieldModelEmissiveB = (float)fldEmissiveValueB.Value / 255f;
            newFieldModelSection.fieldModelEmissiveA = (float)fldEmissiveValueA.Value / 255f;

            newFieldModelSection.fieldModelLightX = (float)fldLightDirValueX.Value;
            newFieldModelSection.fieldModelLightY = (float)fldLightDirValueY.Value;
            newFieldModelSection.fieldModelLightZ = (float)fldLightDirValueZ.Value;

            newFieldModelSection.fieldModelLightX = CheckNumberBox(fldLightDirValueX, newFieldModelSection.fieldModelLightX);
            newFieldModelSection.fieldModelLightY = CheckNumberBox(fldLightDirValueY, newFieldModelSection.fieldModelLightY);
            newFieldModelSection.fieldModelLightZ = CheckNumberBox(fldLightDirValueZ, newFieldModelSection.fieldModelLightZ);

            newFieldModelSection.field52 = CheckNumberBox(fldUnkValueField52, newFieldModelSection.field52);
            newFieldModelSection.field56 = CheckNumberBox(fldUnkValueField56, newFieldModelSection.field56);
            newFieldModelSection.field5A = CheckNumberBox(fldUnkValueField5A, newFieldModelSection.field5A);
            newFieldModelSection.field5E = CheckNumberBox(fldUnkValueField5E, newFieldModelSection.field5E);

            return newFieldModelSection;
        }

        private void UpdateFldAmbSwatch()
        {
            fldAmbSwatch.BackColor = Color.FromArgb((int)fldAmbValueR.Value, (int)fldAmbValueG.Value, (int)fldAmbValueB.Value);
        }

        private void UpdateFldDiffSwatch()
        {
            fldDiffSwatch.BackColor = Color.FromArgb((int)fldDiffValueR.Value, (int)fldDiffValueG.Value, (int)fldDiffValueB.Value);
        }

        private void UpdateFldSpecSwatch()
        {
            fldSpecSwatch.BackColor = Color.FromArgb((int)fldSpecValueR.Value, (int)fldSpecValueG.Value, (int)fldSpecValueB.Value);
        }

        private void UpdateFldEmissiveSwatch()
        {
            fldEmissiveSwatch.BackColor = Color.FromArgb((int)fldEmissiveValueR.Value, (int)fldEmissiveValueG.Value, (int)fldEmissiveValueB.Value);
        }

        private void fldAmbSliderR_Scroll(object sender, EventArgs e)
        {
            fldAmbValueR.Value = fldAmbSliderR.Value;
        }

        private void fldAmbValueR_ValueChanged(object sender, EventArgs e)
        {
            fldAmbSliderR.Value = (int)fldAmbValueR.Value;
            UpdateFldAmbSwatch();
        }

        private void fldAmbSliderG_Scroll(object sender, EventArgs e)
        {
            fldAmbValueG.Value = fldAmbSliderG.Value;
        }

        private void fldAmbValueG_ValueChanged(object sender, EventArgs e)
        {
            fldAmbSliderG.Value = (int)fldAmbValueG.Value;
            UpdateFldAmbSwatch();
        }

        private void fldAmbSliderB_Scroll(object sender, EventArgs e)
        {
            fldAmbValueB.Value = fldAmbSliderB.Value;
        }

        private void fldAmbValueB_ValueChanged(object sender, EventArgs e)
        {
            fldAmbSliderB.Value = (int)fldAmbValueB.Value;
            UpdateFldAmbSwatch();
        }

        private void fldAmbSliderA_Scroll(object sender, EventArgs e)
        {
            fldAmbValueA.Value = fldAmbSliderA.Value;
        }

        private void fldAmbValueA_ValueChanged(object sender, EventArgs e)
        {
            fldAmbSliderA.Value = (int)fldAmbValueA.Value;
        }

        private void fldDiffSliderR_Scroll(object sender, EventArgs e)
        {
            fldDiffValueR.Value = fldDiffSliderR.Value;
        }

        private void fldDiffValueR_ValueChanged(object sender, EventArgs e)
        {
            fldDiffSliderR.Value = (int)fldDiffValueR.Value;
            UpdateFldDiffSwatch();
        }

        private void fldDiffSliderG_Scroll(object sender, EventArgs e)
        {
            fldDiffValueG.Value = fldDiffSliderG.Value;
        }

        private void fldDiffValueG_ValueChanged(object sender, EventArgs e)
        {
            fldDiffSliderG.Value = (int)fldDiffValueG.Value;
            UpdateFldDiffSwatch();
        }

        private void fldDiffSliderB_Scroll(object sender, EventArgs e)
        {
            fldDiffValueB.Value = fldDiffSliderB.Value;
        }

        private void fldDiffValueB_ValueChanged(object sender, EventArgs e)
        {
            fldDiffSliderB.Value = (int)fldDiffValueB.Value;
            UpdateFldDiffSwatch();
        }

        private void fldDiffSliderA_Scroll(object sender, EventArgs e)
        {
            fldDiffValueA.Value = fldDiffSliderA.Value;
        }

        private void fldDiffValueA_ValueChanged(object sender, EventArgs e)
        {
            fldDiffSliderA.Value = (int)fldDiffValueA.Value;
        }

        private void fldSpecSliderR_Scroll(object sender, EventArgs e)
        {
            fldSpecValueR.Value = fldSpecSliderR.Value;
        }

        private void fldSpecValueR_ValueChanged(object sender, EventArgs e)
        {
            fldSpecSliderR.Value = (int)fldSpecValueR.Value;
            UpdateFldSpecSwatch();
        }

        private void fldSpecSliderG_Scroll(object sender, EventArgs e)
        {
            fldSpecValueG.Value = fldSpecSliderG.Value;
        }

        private void fldSpecValueG_ValueChanged(object sender, EventArgs e)
        {
            fldSpecSliderG.Value = (int)fldSpecValueG.Value;
            UpdateFldSpecSwatch();
        }

        private void fldSpecSliderB_Scroll(object sender, EventArgs e)
        {
            fldSpecValueB.Value = fldSpecSliderB.Value;
        }

        private void fldSpecValueB_ValueChanged(object sender, EventArgs e)
        {
            fldSpecSliderB.Value = (int)fldSpecValueB.Value;
            UpdateFldSpecSwatch();
        }

        private void fldSpecSliderA_Scroll(object sender, EventArgs e)
        {
            fldSpecValueA.Value = fldSpecSliderA.Value;
        }

        private void fldSpecValueA_ValueChanged(object sender, EventArgs e)
        {
            fldSpecSliderA.Value = (int)fldSpecValueA.Value;
        }

        private void fldEmissiveSliderR_Scroll(object sender, EventArgs e)
        {
            fldEmissiveValueR.Value = fldEmissiveSliderR.Value;
        }

        private void fldEmissiveValueR_ValueChanged(object sender, EventArgs e)
        {
            fldEmissiveSliderR.Value = (int)fldEmissiveValueR.Value;
            UpdateFldEmissiveSwatch();
        }

        private void fldEmissiveSliderG_Scroll(object sender, EventArgs e)
        {
            fldEmissiveValueG.Value = fldEmissiveSliderG.Value;
        }

        private void fldEmissiveValueG_ValueChanged(object sender, EventArgs e)
        {
            fldEmissiveSliderG.Value = (int)fldEmissiveValueG.Value;
            UpdateFldEmissiveSwatch();
        }

        private void fldEmissiveSliderB_Scroll(object sender, EventArgs e)
        {
            fldEmissiveValueB.Value = fldEmissiveSliderB.Value;
        }

        private void fldEmissiveValueB_ValueChanged(object sender, EventArgs e)
        {
            fldEmissiveSliderB.Value = (int)fldEmissiveValueB.Value;
            UpdateFldEmissiveSwatch();
        }

        private void fldEmissiveSliderA_Scroll(object sender, EventArgs e)
        {
            fldEmissiveValueA.Value = fldEmissiveSliderA.Value;
        }

        private void fldEmissiveValueA_ValueChanged(object sender, EventArgs e)
        {
            fldEmissiveSliderA.Value = (int)fldEmissiveValueA.Value;
        }
    }
}
