using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct PhysicsSection
    {
        public byte enablePhysicsSection; //enable gravity

        public float gravity; //-9999 to 9999, two decimal places.

        public byte enableWindEffects;
        public float windDirectionRangeX;
        public float windDirectionRangeY;
        public float windDirectionRangeZ;
        public float windStrength; //-2 to 2, three decimal places.
        public float windStrengthModifier; //-2 to 2, three decimal places.
        public float windCycleTime; //-2 to 2, three decimal places.
        public float windCycleDelay; //-2 to 2, three decimal places.

        public PhysicsSection(BinaryObjectReader reader)
        {
            enablePhysicsSection = reader.ReadByte();

            gravity = reader.ReadSingle();

            enableWindEffects = reader.ReadByte();
            windDirectionRangeX = reader.ReadSingle();
            windDirectionRangeY = reader.ReadSingle();
            windDirectionRangeZ = reader.ReadSingle();
            windStrength = reader.ReadSingle();
            windStrengthModifier = reader.ReadSingle();
            windCycleTime = reader.ReadSingle();
            windCycleDelay = reader.ReadSingle();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(enablePhysicsSection);

            writer.WriteSingle(gravity);

            writer.WriteByte(enableWindEffects);
            writer.WriteSingle(windDirectionRangeX);
            writer.WriteSingle(windDirectionRangeY);
            writer.WriteSingle(windDirectionRangeZ);
            writer.WriteSingle(windStrength);
            writer.WriteSingle(windStrengthModifier);
            writer.WriteSingle(windCycleTime);
            writer.WriteSingle(windCycleDelay);
        }
    }
}
