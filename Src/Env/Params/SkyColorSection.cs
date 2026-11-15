using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct SkyColorSection //called clear color in the 010 template
    {
        public byte skyColorR;
        public byte skyColorG;
        public byte skyColorB;
        public byte skyColorA;

        //no idea what these are
        public byte extraByteA;
        public byte extraByteB;
        public byte extraByteC;
        public byte extraByteD;

        public SkyColorSection(BinaryObjectReader reader)
        {
            skyColorR = reader.ReadByte();
            skyColorG = reader.ReadByte();
            skyColorB = reader.ReadByte();
            skyColorA = reader.ReadByte();

            extraByteA = reader.ReadByte();
            extraByteB = reader.ReadByte();
            extraByteC = reader.ReadByte();
            extraByteD = reader.ReadByte();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(skyColorR);
            writer.WriteByte(skyColorG);
            writer.WriteByte(skyColorB);
            writer.WriteByte(skyColorA);

            writer.WriteByte(extraByteA);
            writer.WriteByte(extraByteB);
            writer.WriteByte(extraByteC);
            writer.WriteByte(extraByteD);
        }
    }
}
