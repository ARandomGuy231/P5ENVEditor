using P5ENVEditor.Env;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor
{
    public partial class MainWindow
    {
        private void DisplayPhysicsParams()
        {
            enablePhysicsBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.physicsSection.enablePhysicsSection;

            SetNumberBox(gravityValue, (decimal)EnvFunctions.loadedENVParams.physicsSection.gravity);

            enableWindBox.CheckState = (CheckState)EnvFunctions.loadedENVParams.physicsSection.enableWindEffects;
            SetNumberBox(windDirectionValueX, (decimal)EnvFunctions.loadedENVParams.physicsSection.windDirectionRangeX);
            SetNumberBox(windDirectionValueY, (decimal)EnvFunctions.loadedENVParams.physicsSection.windDirectionRangeY);
            SetNumberBox(windDirectionValueZ, (decimal)EnvFunctions.loadedENVParams.physicsSection.windDirectionRangeZ);
            SetNumberBox(windStrengthValue, (decimal)EnvFunctions.loadedENVParams.physicsSection.windStrength);
            SetNumberBox(windStrengthModifierValue, (decimal)EnvFunctions.loadedENVParams.physicsSection.windStrengthModifier);
            SetNumberBox(windCycleTimeValue, (decimal)EnvFunctions.loadedENVParams.physicsSection.windCycleTime);
            SetNumberBox(windCycleDelayValue, (decimal)EnvFunctions.loadedENVParams.physicsSection.windCycleDelay);
        }

        private PhysicsSection CreatePhysicsSection()
        {
            var newPhysicsSection = EnvFunctions.loadedENVParams.physicsSection;

            newPhysicsSection.enablePhysicsSection = (byte)enablePhysicsBox.CheckState;
            
            newPhysicsSection.gravity = CheckNumberBox(gravityValue, newPhysicsSection.gravity);

            newPhysicsSection.enableWindEffects = (byte)enableWindBox.CheckState;
            newPhysicsSection.windDirectionRangeX = CheckNumberBox(windDirectionValueX, newPhysicsSection.windDirectionRangeX);
            newPhysicsSection.windDirectionRangeY = CheckNumberBox(windDirectionValueY, newPhysicsSection.windDirectionRangeY);
            newPhysicsSection.windDirectionRangeZ = CheckNumberBox(windDirectionValueZ, newPhysicsSection.windDirectionRangeZ);
            newPhysicsSection.windStrength = CheckNumberBox(windStrengthValue, newPhysicsSection.windStrength);
            newPhysicsSection.windStrengthModifier = CheckNumberBox(windStrengthModifierValue, newPhysicsSection.windStrengthModifier);
            newPhysicsSection.windCycleTime = CheckNumberBox(windCycleTimeValue, newPhysicsSection.windCycleTime);
            newPhysicsSection.windCycleDelay = CheckNumberBox(windCycleDelayValue, newPhysicsSection.windCycleDelay);

            return newPhysicsSection;
        }
    }
}
