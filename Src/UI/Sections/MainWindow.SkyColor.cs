using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplaySkyColorParams()
        {
            SetNumberBox(skyColorValueR, EnvFunctions.loadedENVParams.skyColorSection.skyColorR);
            SetNumberBox(skyColorValueG, EnvFunctions.loadedENVParams.skyColorSection.skyColorG);
            SetNumberBox(skyColorValueB, EnvFunctions.loadedENVParams.skyColorSection.skyColorB);
            SetNumberBox(skyColorValueA, EnvFunctions.loadedENVParams.skyColorSection.skyColorA);
        }

        private SkyColorSection CreateSkyColorSection()
        {
            var newSkyColorSection = EnvFunctions.loadedENVParams.skyColorSection;

            newSkyColorSection.skyColorR = CheckNumberBox(skyColorValueR, newSkyColorSection.skyColorR);
            newSkyColorSection.skyColorG = CheckNumberBox(skyColorValueG, newSkyColorSection.skyColorG);
            newSkyColorSection.skyColorB = CheckNumberBox(skyColorValueB, newSkyColorSection.skyColorB);
            newSkyColorSection.skyColorA = CheckNumberBox(skyColorValueA, newSkyColorSection.skyColorA);

            return newSkyColorSection;
        }

        private void UpdateSkyColorSwatch()
        {
            skyColorSwatch.BackColor = Color.FromArgb((int)skyColorValueR.Value, (int)skyColorValueG.Value, (int)skyColorValueB.Value);
        }

        private void skyColorSliderR_Scroll(object sender, EventArgs e)
        {
            skyColorValueR.Value = skyColorSliderR.Value;
        }

        private void skyColorValueR_ValueChanged(object sender, EventArgs e)
        {
            skyColorSliderR.Value = (int)skyColorValueR.Value;
            UpdateSkyColorSwatch();
        }

        private void skyColorSliderG_Scroll(object sender, EventArgs e)
        {
            skyColorValueG.Value = skyColorSliderG.Value;
        }

        private void skyColorValueG_ValueChanged(object sender, EventArgs e)
        {
            skyColorSliderG.Value = (int)skyColorValueG.Value;
            UpdateSkyColorSwatch();
        }

        private void skyColorSliderB_Scroll(object sender, EventArgs e)
        {
            skyColorValueB.Value = skyColorSliderB.Value;
        }

        private void skyColorValueB_ValueChanged(object sender, EventArgs e)
        {
            skyColorSliderB.Value = (int)skyColorValueB.Value;
            UpdateSkyColorSwatch();
        }

        private void skyColorSliderA_Scroll(object sender, EventArgs e)
        {
            skyColorValueA.Value = skyColorSliderA.Value;
        }

        private void skyColorValueA_ValueChanged(object sender, EventArgs e)
        {
            skyColorSliderA.Value = (int)skyColorValueA.Value;
        }
    }
}
