using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayFogParams()
        {
            enableFogBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.fogSection.enableFog;
            enableAmbFogBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.fogSection.enableAmbientFog;
            fogModeBox.SelectedIndex = EnvFunctions.loadedENVParams.fogSection.fogMode;
            fogCamPlaneBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.fogSection.toggleFogCameraPlane;
            SetNumberBox(fogStartDistanceValue, (decimal)EnvFunctions.loadedENVParams.fogSection.fogStartDistance);
            SetNumberBox(fogEndDistanceValue, (decimal)EnvFunctions.loadedENVParams.fogSection.fogEndDistance);
            fogColorValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.fogRed);
            fogColorValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.fogGreen);
            fogColorValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.fogBlue);
            fogColorValueO.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.fogOpacity);

            enableFloorFogBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.fogSection.enableFloorFog;
            SetNumberBox(floorFogStartHeightValue, (decimal)EnvFunctions.loadedENVParams.fogSection.floorFogStartHeight);
            SetNumberBox(floorFogEndHeightValue, (decimal)EnvFunctions.loadedENVParams.fogSection.floorFogEndHeight);
            floorFogColorValueR.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.floorFogRed);
            floorFogColorValueG.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.floorFogGreen);
            floorFogColorValueB.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.floorFogBlue);
            floorFogColorValueO.Value = FloatToRGB(EnvFunctions.loadedENVParams.fogSection.floorFogOpacity);
        }

        private FogSection CreateFogSection()
        {
            var newFogSection = EnvFunctions.loadedENVParams.fogSection;

            newFogSection.enableFog = (byte)enableFogBox.CheckState;

            //Game crashes if amb fog is enabled, so keep whatever the original file has if we aren't editing it.
            if (enableAmbFogBox.Enabled)
            {
                newFogSection.enableAmbientFog = (byte)enableAmbFogBox.CheckState;
            }

            newFogSection.fogMode = (byte)fogModeBox.SelectedIndex;
            newFogSection.toggleFogCameraPlane = (byte)fogCamPlaneBox.CheckState;
            newFogSection.fogStartDistance = CheckNumberBox(fogStartDistanceValue, newFogSection.fogStartDistance);
            newFogSection.fogEndDistance = CheckNumberBox(fogEndDistanceValue, newFogSection.fogEndDistance);
            newFogSection.fogRed = (float)fogColorValueR.Value / 255f;
            newFogSection.fogGreen = (float)fogColorValueG.Value / 255f;
            newFogSection.fogBlue = (float)fogColorValueB.Value / 255f;
            newFogSection.fogOpacity = (float)fogColorValueO.Value / 255f;

            newFogSection.enableFloorFog = (byte)enableFloorFogBox.CheckState;
            newFogSection.floorFogStartHeight = CheckNumberBox(floorFogStartHeightValue, newFogSection.floorFogStartHeight);
            newFogSection.floorFogEndHeight = CheckNumberBox(floorFogEndHeightValue, newFogSection.floorFogEndHeight);
            newFogSection.floorFogRed = (float)floorFogColorValueR.Value / 255f;
            newFogSection.floorFogGreen = (float)floorFogColorValueG.Value / 255f;
            newFogSection.floorFogBlue = (float)floorFogColorValueB.Value / 255f;
            newFogSection.floorFogOpacity = (float)floorFogColorValueO.Value / 255f;

            return newFogSection;
        }

        private void UpdateFogSwatch()
        {
            fogColorSwatch.BackColor = Color.FromArgb((int)fogColorValueR.Value, (int)fogColorValueG.Value, (int)fogColorValueB.Value);
        }

        private void UpdateFloorFogSwatch()
        {
            floorFogColorSwatch.BackColor = Color.FromArgb((int)floorFogColorValueR.Value, (int)floorFogColorValueG.Value, (int)floorFogColorValueB.Value);
        }

        private void UpdateFogHex()
        {
            fogColorHex.Text = $"#{fogColorSwatch.BackColor.R:X2}{fogColorSwatch.BackColor.G:X2}{fogColorSwatch.BackColor.B:X2}";
        }

        private void UpdateFloorFogHex()
        {
            floorFogColorHex.Text = $"#{floorFogColorSwatch.BackColor.R:X2}{floorFogColorSwatch.BackColor.G:X2}{floorFogColorSwatch.BackColor.B:X2}";
        }

        private void fogColorSliderR_Scroll(object sender, EventArgs e)
        {
            fogColorValueR.Value = fogColorSliderR.Value;
        }

        private void fogColorValueR_ValueChanged(object sender, EventArgs e)
        {
            fogColorSliderR.Value = (int)fogColorValueR.Value;
            UpdateFogSwatch();
            UpdateFogHex();
        }

        private void fogColorSliderG_Scroll(object sender, EventArgs e)
        {
            fogColorValueG.Value = fogColorSliderG.Value;
        }

        private void fogColorValueG_ValueChanged(object sender, EventArgs e)
        {
            fogColorSliderG.Value = (int)fogColorValueG.Value;
            UpdateFogSwatch();
            UpdateFogHex();
        }

        private void fogColorSliderB_Scroll(object sender, EventArgs e)
        {
            fogColorValueB.Value = fogColorSliderB.Value;
        }

        private void fogColorValueB_ValueChanged(object sender, EventArgs e)
        {
            fogColorSliderB.Value = (int)fogColorValueB.Value;
            UpdateFogSwatch();
            UpdateFogHex();
        }

        private void fogColorSliderO_Scroll(object sender, EventArgs e)
        {
            fogColorValueO.Value = fogColorSliderO.Value;
        }

        private void fogColorValueO_ValueChanged(object sender, EventArgs e)
        {
            fogColorSliderO.Value = (int)fogColorValueO.Value;
        }

        private void floorFogColorSliderR_Scroll(object sender, EventArgs e)
        {
            floorFogColorValueR.Value = floorFogColorSliderR.Value;
        }

        private void floorFogColorValueR_ValueChanged(object sender, EventArgs e)
        {
            floorFogColorSliderR.Value = (int)floorFogColorValueR.Value;
            UpdateFloorFogSwatch();
            UpdateFloorFogHex();
        }

        private void floorFogColorSliderG_Scroll(object sender, EventArgs e)
        {
            floorFogColorValueG.Value = floorFogColorSliderG.Value;
        }

        private void floorFogColorValueG_ValueChanged(object sender, EventArgs e)
        {
            floorFogColorSliderG.Value = (int)floorFogColorValueG.Value;
            UpdateFloorFogSwatch();
            UpdateFloorFogHex();
        }

        private void floorFogColorSliderB_Scroll(object sender, EventArgs e)
        {
            floorFogColorValueB.Value = floorFogColorSliderB.Value;
        }

        private void floorFogColorValueB_ValueChanged(object sender, EventArgs e)
        {
            floorFogColorSliderB.Value = (int)floorFogColorValueB.Value;
            UpdateFloorFogSwatch();
            UpdateFloorFogHex();
        }

        private void floorFogColorSliderO_Scroll(object sender, EventArgs e)
        {
            floorFogColorValueO.Value = floorFogColorSliderO.Value;
        }

        private void floorFogColorValueO_ValueChanged(object sender, EventArgs e)
        {
            floorFogColorSliderO.Value = (int)floorFogColorValueO.Value;
        }

        private void fogColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(fogColorHex, fogColorValueR, fogColorValueG, fogColorValueB);
        }

        private void floorFogColorHex_TextChanged(object sender, EventArgs e)
        {
            UpdateColorFromHex(floorFogColorHex, floorFogColorValueR, floorFogColorValueG, floorFogColorValueB);
        }
    }
}
