using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayCharacterModelParams()
        {
            charAmbValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelAmbientR);
            charAmbValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelAmbientG);
            charAmbValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelAmbientB);
            charAmbValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelAmbientA);

            charDiffValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelDiffuseR);
            charDiffValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelDiffuseG);
            charDiffValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelDiffuseB);
            charDiffValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelDiffuseA);

            charSpecValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelSpecularR);
            charSpecValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelSpecularG);
            charSpecValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelSpecularB);
            charSpecValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelSpecularA);

            charEmissiveValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelEmissiveR);
            charEmissiveValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelEmissiveG);
            charEmissiveValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelEmissiveB);
            charEmissiveValueA.Value = FloatToRGB(EnvFunctions.loadedENVParams.characterModelSection.characterModelEmissiveA);

            SetNumberBox(charLightDirValueX, (decimal)EnvFunctions.loadedENVParams.characterModelSection.characterModelLightX);
            SetNumberBox(charLightDirValueY, (decimal)EnvFunctions.loadedENVParams.characterModelSection.characterModelLightY);
            SetNumberBox(charLightDirValueZ, (decimal)EnvFunctions.loadedENVParams.characterModelSection.characterModelLightZ);

            SetNumberBox(camFovValue, (decimal)EnvFunctions.loadedENVParams.characterModelSection.cameraFOV);
            SetNumberBox(camNearClipValue, (decimal)EnvFunctions.loadedENVParams.characterModelSection.modelNearClip);
            SetNumberBox(camFarClipValue, (decimal)EnvFunctions.loadedENVParams.characterModelSection.modelFarClip);

            SetNumberBox(charUnkValueField16C, (decimal)EnvFunctions.loadedENVParams.characterModelSection.field16C);
            SetNumberBox(charUnkValueField170, (decimal)EnvFunctions.loadedENVParams.characterModelSection.field170);
            SetNumberBox(charUnkValueField174, (decimal)EnvFunctions.loadedENVParams.characterModelSection.field174);
            SetNumberBox(charUnkValueField178, (decimal)EnvFunctions.loadedENVParams.characterModelSection.field178);
        }

        private CharacterModelSection CreateCharacterModelSection()
        {
            var newCharacterModelSection = EnvFunctions.loadedENVParams.characterModelSection;

            newCharacterModelSection.characterModelAmbientR = (float)charAmbValueR.Value / 255f;
            newCharacterModelSection.characterModelAmbientG = (float)charAmbValueG.Value / 255f;
            newCharacterModelSection.characterModelAmbientB = (float)charAmbValueB.Value / 255f;
            newCharacterModelSection.characterModelAmbientA = (float)charAmbValueA.Value / 255f;

            newCharacterModelSection.characterModelDiffuseR = (float)charDiffValueR.Value / 255f;
            newCharacterModelSection.characterModelDiffuseG = (float)charDiffValueG.Value / 255f;
            newCharacterModelSection.characterModelDiffuseB = (float)charDiffValueB.Value / 255f;
            newCharacterModelSection.characterModelDiffuseA = (float)charDiffValueA.Value / 255f;

            newCharacterModelSection.characterModelSpecularR = (float)charSpecValueR.Value / 255f;
            newCharacterModelSection.characterModelSpecularG = (float)charSpecValueG.Value / 255f;
            newCharacterModelSection.characterModelSpecularB = (float)charSpecValueB.Value / 255f;
            newCharacterModelSection.characterModelSpecularA = (float)charSpecValueA.Value / 255f;

            newCharacterModelSection.characterModelEmissiveR = (float)charEmissiveValueR.Value / 255f;
            newCharacterModelSection.characterModelEmissiveG = (float)charEmissiveValueG.Value / 255f;
            newCharacterModelSection.characterModelEmissiveB = (float)charEmissiveValueB.Value / 255f;
            newCharacterModelSection.characterModelEmissiveA = (float)charEmissiveValueA.Value / 255f;

            newCharacterModelSection.characterModelLightX = CheckNumberBox(charLightDirValueX, newCharacterModelSection.characterModelLightX);
            newCharacterModelSection.characterModelLightY = CheckNumberBox(charLightDirValueY, newCharacterModelSection.characterModelLightY);
            newCharacterModelSection.characterModelLightZ = CheckNumberBox(charLightDirValueZ, newCharacterModelSection.characterModelLightZ);

            newCharacterModelSection.cameraFOV = CheckNumberBox(camFovValue, newCharacterModelSection.cameraFOV);
            newCharacterModelSection.modelNearClip = CheckNumberBox(camNearClipValue, newCharacterModelSection.modelNearClip);
            newCharacterModelSection.modelFarClip = CheckNumberBox(camFarClipValue, newCharacterModelSection.modelFarClip);

            newCharacterModelSection.field16C = CheckNumberBox(charUnkValueField16C, newCharacterModelSection.field16C);
            newCharacterModelSection.field170 = CheckNumberBox(charUnkValueField170, newCharacterModelSection.field170);
            newCharacterModelSection.field174 = CheckNumberBox(charUnkValueField174, newCharacterModelSection.field174);
            newCharacterModelSection.field178 = CheckNumberBox(charUnkValueField178, newCharacterModelSection.field178);

            return newCharacterModelSection;
        }

        private void UpdateCharAmbSwatch()
        {
            charAmbSwatch.BackColor = Color.FromArgb((int)charAmbValueR.Value, (int)charAmbValueG.Value, (int)charAmbValueB.Value);
        }

        private void UpdateCharDiffSwatch()
        {
            charDiffSwatch.BackColor = Color.FromArgb((int)charDiffValueR.Value, (int)charDiffValueG.Value, (int)charDiffValueB.Value);
        }

        private void UpdateCharSpecSwatch()
        {
            charSpecSwatch.BackColor = Color.FromArgb((int)charSpecValueR.Value, (int)charSpecValueG.Value, (int)charSpecValueB.Value);
        }

        private void UpdateCharEmissiveSwatch()
        {
            charEmissiveSwatch.BackColor = Color.FromArgb((int)charEmissiveValueR.Value, (int)charEmissiveValueG.Value, (int)charEmissiveValueB.Value);
        }

        private void UpdateCharAmbHex()
        {
            charAmbColorHex.Text = $"#{charAmbSwatch.BackColor.R:X2}{charAmbSwatch.BackColor.G:X2}{charAmbSwatch.BackColor.B:X2}";
        }

        private void UpdateCharDiffHex()
        {
            charDiffColorHex.Text = $"#{charDiffSwatch.BackColor.R:X2}{charDiffSwatch.BackColor.G:X2}{charDiffSwatch.BackColor.B:X2}";
        }

        private void UpdateCharSpecHex()
        {
            charSpecColorHex.Text = $"#{charSpecSwatch.BackColor.R:X2}{charSpecSwatch.BackColor.G:X2}{charSpecSwatch.BackColor.B:X2}";
        }

        private void UpdateCharEmissiveHex()
        {
            charEmissiveColorHex.Text = $"#{charEmissiveSwatch.BackColor.R:X2}{charEmissiveSwatch.BackColor.G:X2}{charEmissiveSwatch.BackColor.B:X2}";
        }

        private void charAmbSliderR_Scroll(object sender, EventArgs e)
        {
            charAmbValueR.Value = charAmbSliderR.Value;
        }

        private void charAmbValueR_ValueChanged(object sender, EventArgs e)
        {
            charAmbSliderR.Value = (int)charAmbValueR.Value;
            UpdateCharAmbSwatch();
            UpdateCharAmbHex();
        }

        private void charAmbSliderG_Scroll(object sender, EventArgs e)
        {
            charAmbValueG.Value = charAmbSliderG.Value;
        }

        private void charAmbValueG_ValueChanged(object sender, EventArgs e)
        {
            charAmbSliderG.Value = (int)charAmbValueG.Value;
            UpdateCharAmbSwatch();
            UpdateCharAmbHex();
        }

        private void charAmbSliderB_Scroll(object sender, EventArgs e)
        {
            charAmbValueB.Value = charAmbSliderB.Value;
        }

        private void charAmbValueB_ValueChanged(object sender, EventArgs e)
        {
            charAmbSliderB.Value = (int)charAmbValueB.Value;
            UpdateCharAmbSwatch();
            UpdateCharAmbHex();
        }

        private void charAmbSliderA_Scroll(object sender, EventArgs e)
        {
            charAmbValueA.Value = charAmbSliderA.Value;
        }

        private void charAmbValueA_ValueChanged(object sender, EventArgs e)
        {
            charAmbSliderA.Value = (int)charAmbValueA.Value;
        }

        private void charDiffSliderR_Scroll(object sender, EventArgs e)
        {
            charDiffValueR.Value = charDiffSliderR.Value;
        }

        private void charDiffValueR_ValueChanged(object sender, EventArgs e)
        {
            charDiffSliderR.Value = (int)charDiffValueR.Value;
            UpdateCharDiffSwatch();
            UpdateCharDiffHex();
        }

        private void charDiffSliderG_Scroll(object sender, EventArgs e)
        {
            charDiffValueG.Value = charDiffSliderG.Value;
        }

        private void charDiffValueG_ValueChanged(object sender, EventArgs e)
        {
            charDiffSliderG.Value = (int)charDiffValueG.Value;
            UpdateCharDiffSwatch();
            UpdateCharDiffHex();
        }

        private void charDiffSliderB_Scroll(object sender, EventArgs e)
        {
            charDiffValueB.Value = charDiffSliderB.Value;
        }

        private void charDiffValueB_ValueChanged(object sender, EventArgs e)
        {
            charDiffSliderB.Value = (int)charDiffValueB.Value;
            UpdateCharDiffSwatch();
            UpdateCharDiffHex();
        }

        private void charDiffSliderA_Scroll(object sender, EventArgs e)
        {
            charDiffValueA.Value = charDiffSliderA.Value;
        }

        private void charDiffValueA_ValueChanged(object sender, EventArgs e)
        {
            charDiffSliderA.Value = (int)charDiffValueA.Value;
        }

        private void charSpecSliderR_Scroll(object sender, EventArgs e)
        {
            charSpecValueR.Value = charSpecSliderR.Value;
        }

        private void charSpecValueR_ValueChanged(object sender, EventArgs e)
        {
            charSpecSliderR.Value = (int)charSpecValueR.Value;
            UpdateCharSpecSwatch();
            UpdateCharSpecHex();
        }

        private void charSpecSliderG_Scroll(object sender, EventArgs e)
        {
            charSpecValueG.Value = charSpecSliderG.Value;
        }

        private void charSpecValueG_ValueChanged(object sender, EventArgs e)
        {
            charSpecSliderG.Value = (int)charSpecValueG.Value;
            UpdateCharSpecSwatch();
            UpdateCharSpecHex();
        }

        private void charSpecSliderB_Scroll(object sender, EventArgs e)
        {
            charSpecValueB.Value = charSpecSliderB.Value;
        }

        private void charSpecValueB_ValueChanged(object sender, EventArgs e)
        {
            charSpecSliderB.Value = (int)charSpecValueB.Value;
            UpdateCharSpecSwatch();
            UpdateCharSpecHex();
        }

        private void charSpecSliderA_Scroll(object sender, EventArgs e)
        {
            charSpecValueA.Value = charSpecSliderA.Value;
        }

        private void charSpecValueA_ValueChanged(object sender, EventArgs e)
        {
            charSpecSliderA.Value = (int)charSpecValueA.Value;
        }

        private void charEmissiveSliderR_Scroll(object sender, EventArgs e)
        {
            charEmissiveValueR.Value = charEmissiveSliderR.Value;
        }

        private void charEmissiveValueR_ValueChanged(object sender, EventArgs e)
        {
            charEmissiveSliderR.Value = (int)charEmissiveValueR.Value;
            UpdateCharEmissiveSwatch();
            UpdateCharEmissiveHex();
        }

        private void charEmissiveSliderG_Scroll(object sender, EventArgs e)
        {
            charEmissiveValueG.Value = charEmissiveSliderG.Value;
        }

        private void charEmissiveValueG_ValueChanged(object sender, EventArgs e)
        {
            charEmissiveSliderG.Value = (int)charEmissiveValueG.Value;
            UpdateCharEmissiveSwatch();
            UpdateCharEmissiveHex();
        }

        private void charEmissiveSliderB_Scroll(object sender, EventArgs e)
        {
            charEmissiveValueB.Value = charEmissiveSliderB.Value;
        }

        private void charEmissiveValueB_ValueChanged(object sender, EventArgs e)
        {
            charEmissiveSliderB.Value = (int)charEmissiveValueB.Value;
            UpdateCharEmissiveSwatch();
            UpdateCharEmissiveHex();
        }

        private void charEmissiveSliderA_Scroll(object sender, EventArgs e)
        {
            charEmissiveValueA.Value = charEmissiveSliderA.Value;
        }

        private void charEmissiveValueA_ValueChanged(object sender, EventArgs e)
        {
            charEmissiveSliderA.Value = (int)charEmissiveValueA.Value;
        }

        private void charAmbColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(charAmbColorHex, charAmbValueR, charAmbValueG, charAmbValueB);
        }

        private void charDiffColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(charDiffColorHex, charDiffValueR, charDiffValueG, charDiffValueB);
        }

        private void charSpecColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(charSpecColorHex, charSpecValueR, charSpecValueG, charSpecValueB);
        }

        private void charEmissiveColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(charEmissiveColorHex, charEmissiveValueR, charEmissiveValueG, charEmissiveValueB);
        }
    }
}
