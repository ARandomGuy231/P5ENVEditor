using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct FieldShadowSection
    {
        public float fieldShadowFarClip; //called depth range in beta 0-9999, two decimal places.
        public float field294;
        public float ambientShadowBrightness; //is actually diffuse brightness 0-1, two decimal places.
        public float field29C; //shadow bias -3 to 3, two decimal places.
        public uint field2A0; //seems to affect the first two checkboxes in the shadow section in beta, changing the number depends on which are enabled and only one byte changes between the two.
        public float fieldShadowNearClip; //might actually be shadow cascade split rate 0.01-0.99, two decimal places.
        public float fieldShadowBrightness; //is actually ambient brightness 0-1, two decimal places.
        public byte field2AC;
        public byte field2AD;
        public byte field2AE;
        public byte field2AF;

        //Royal Only
        public float shadowColorRed;
        public float shadowColorGreen;
        public float shadowColorBlue;
        public float shadowColorAlpha;

        public FieldShadowSection(BinaryObjectReader reader)
        {
            fieldShadowFarClip = reader.ReadSingle();
            field294 = reader.ReadSingle();
            ambientShadowBrightness = reader.ReadSingle();
            field29C = reader.ReadSingle();
            field2A0 = reader.ReadUInt32();
            fieldShadowNearClip = reader.ReadSingle();
            fieldShadowBrightness = reader.ReadSingle();
            field2AC = reader.ReadByte();
            field2AD = reader.ReadByte();
            field2AE = reader.ReadByte();
            field2AF = reader.ReadByte();

            if (EnvFunctions.envVersionCheck >= 0x1105100)
            {
                shadowColorRed = reader.ReadSingle();
                shadowColorGreen = reader.ReadSingle();
                shadowColorBlue = reader.ReadSingle();
                shadowColorAlpha = reader.ReadSingle();
            }
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteSingle(fieldShadowFarClip);
            writer.WriteSingle(field294);
            writer.WriteSingle(ambientShadowBrightness);
            writer.WriteSingle(field29C);
            writer.WriteUInt32(field2A0);
            writer.WriteSingle(fieldShadowNearClip);
            writer.WriteSingle(fieldShadowBrightness);
            writer.WriteByte(field2AC);
            writer.WriteByte(field2AD);
            writer.WriteByte(field2AE);
            writer.WriteByte(field2AF);

            if (EnvFunctions.loadedENVHeader.gfsVersion >= 0x1105100)
            {
                writer.WriteSingle(shadowColorRed);
                writer.WriteSingle(shadowColorGreen);
                writer.WriteSingle(shadowColorBlue);
                writer.WriteSingle(shadowColorAlpha);

            }
        }
    }
}
