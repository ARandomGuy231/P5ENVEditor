using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayColorCorrectionParams()
        {
            enableColorCorrectionBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.colorCorrectionSection.enableColorGrading;

            SetNumberBox(colorCorrectionValueC, (decimal)EnvFunctions.loadedENVParams.colorCorrectionSection.cyan);
            SetNumberBox(colorCorrectionValueM, (decimal)EnvFunctions.loadedENVParams.colorCorrectionSection.magenta);
            SetNumberBox(colorCorrectionValueY, (decimal)EnvFunctions.loadedENVParams.colorCorrectionSection.yellow);

            SetNumberBox(colorCorrectionValueDodge, (decimal)EnvFunctions.loadedENVParams.colorCorrectionSection.dodge);
            SetNumberBox(colorCorrectionValueBurn, (decimal)EnvFunctions.loadedENVParams.colorCorrectionSection.burn);
        }

        private ColorCorrectionSection CreateColorCorrectionSection()
        {
            var newColorCorrectionSection = EnvFunctions.loadedENVParams.colorCorrectionSection;

            newColorCorrectionSection.enableColorGrading = (byte)enableColorCorrectionBox.CheckState;

            newColorCorrectionSection.cyan = CheckNumberBox(colorCorrectionValueC, newColorCorrectionSection.cyan);
            newColorCorrectionSection.magenta = CheckNumberBox(colorCorrectionValueM, newColorCorrectionSection.magenta);
            newColorCorrectionSection.yellow = CheckNumberBox(colorCorrectionValueY, newColorCorrectionSection.yellow);

            newColorCorrectionSection.dodge = CheckNumberBox(colorCorrectionValueDodge, newColorCorrectionSection.dodge);
            newColorCorrectionSection.burn = CheckNumberBox(colorCorrectionValueBurn, newColorCorrectionSection.burn);

            return newColorCorrectionSection;
        }
    }
}
