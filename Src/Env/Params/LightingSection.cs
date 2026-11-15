using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct LightingSection
    {
        public byte enableGraphicalOutput;
        public byte enableToneMap;
        public byte enableStarGlare;
        public byte enableAdaptedLumAuto;
        public float middleGray; //0-10 bloom threshold is more accurate, called medium brightness in beta, two decimal places.
        public float bloomScale; //bloom strength 0-4, two decimal places.
        public float adaptedLum; //star stength 0-4, two decimal places.
        public float elapsedTime; //0-1, after bloomScale in the beta, but it's called adaptive brightness, lower value means stronger bloom, two decimal places.
        public float starGlareScale; //no idea if this is correct, can't find it in the beta editor

        public float starGlareLength; //0.10-2, two decimal places.
        public float starGlareChromaticAberration; //0-5, two decimal places.
        public float starGlareSI; //glare rotation/tilt 0-360, two decimal places.
        public uint starGlareLines; //2, 3 or 4.

        public LightingSection(BinaryObjectReader reader)
        {
            enableGraphicalOutput = reader.ReadByte();
            enableToneMap = reader.ReadByte();
            enableStarGlare = reader.ReadByte();
            enableAdaptedLumAuto = reader.ReadByte();
            middleGray = reader.ReadSingle();
            bloomScale = reader.ReadSingle();
            adaptedLum = reader.ReadSingle();
            elapsedTime = reader.ReadSingle();
            starGlareScale = reader.ReadSingle();

            starGlareLength = reader.ReadSingle();
            starGlareChromaticAberration = reader.ReadSingle();
            starGlareSI = reader.ReadSingle();
            starGlareLines = reader.ReadUInt32();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(enableGraphicalOutput);
            writer.WriteByte(enableToneMap);
            writer.WriteByte(enableStarGlare);
            writer.WriteByte(enableAdaptedLumAuto);
            writer.WriteSingle(middleGray);
            writer.WriteSingle(bloomScale);
            writer.WriteSingle(adaptedLum);
            writer.WriteSingle(elapsedTime);
            writer.WriteSingle(starGlareScale);

            writer.WriteSingle(starGlareLength);
            writer.WriteSingle(starGlareChromaticAberration);
            writer.WriteSingle(starGlareSI);
            writer.WriteUInt32(starGlareLines);
        }
    }
}
