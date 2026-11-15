using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct ColorCorrectionSection
    {
        public byte enableColorGrading;
        public float cyan; //-1 to 1, two decimal places.
        public float magenta; //-1 to 1, two decimal places.
        public float yellow; //-1 to 1, two decimal places.

        public float dodge; //0-0.99, two decimal places.
        public float burn; //0-0.99, two decimal places.

        public ColorCorrectionSection(BinaryObjectReader reader)
        {
            enableColorGrading = reader.ReadByte();
            cyan = reader.ReadSingle();
            magenta = reader.ReadSingle();
            yellow = reader.ReadSingle();

            dodge = reader.ReadSingle();
            burn = reader.ReadSingle();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(enableColorGrading);
            writer.WriteSingle(cyan);
            writer.WriteSingle(magenta);
            writer.WriteSingle(yellow);

            writer.WriteSingle(dodge);
            writer.WriteSingle(burn);
        }
    }
}
