using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct UnknownSection
    {
        public byte field1F1; //diffusion filter toggle? (not present in the beta settings).
        public float field1F2; //diffusion filter medium brightness, two decimal places. 0-100
        public float diffFilterStrength; //float version of field1F6 (similar to bloom scale in the lighting section), two decimal places. 0-1
        public byte field1F6;
        public byte field1F7;
        public byte field1F8;
        public byte field1F9;
        public float field1FA; //diffusion filter adaptive brightness (again?), two decimal places. 0-2

        public byte enableDOF;
        public float dofFocalPlane; //0-100, two decimal places.
        public float dofNearBlurPlane; //0-100, two decimal places.
        public float dofFarBlurPlane; //0-100, two decimal places.
        public float dofFarBlurLimit; //0-100, two decimal places.
        public float dofBlurScale; //0.5-1, two decimal places.
        public uint dofGaussType; //0 to 4, drop down option: 5x5 Gauss, Gauss Filter 1, Gauss Filter 3, Gauss Filter 5, Gauss Filter 7

        //SSAO settings are absent in the beta and appears to be non-functional when enabled. Go with 0-10 for everything except depth range, make that 0-1000
        public byte enableSSAO;
        public float ssaoOccluderRadius;
        public float ssaoFallOffRadius;
        public float ssaoBlurScale;
        public float ssaoBrightness;
        public float ssaoDepthRange;

        public byte disableUnknownFlaggedSection;

        public UnknownSection(BinaryObjectReader reader)
        {
            field1F1 = reader.ReadByte();
            field1F2 = reader.ReadSingle();

            if (EnvFunctions.envVersionCheck != 0x1104910)
            {
                diffFilterStrength = reader.ReadSingle();
            }
            else
            {
                field1F6 = reader.ReadByte();
                field1F7 = reader.ReadByte();
                field1F8 = reader.ReadByte();
                field1F9 = reader.ReadByte();
            }

            field1FA = reader.ReadSingle();

            if (EnvFunctions.envVersionCheck > 0x1105040)
            {
                enableDOF = reader.ReadByte();
                dofFocalPlane = reader.ReadSingle();
                dofNearBlurPlane = reader.ReadSingle();
                dofFarBlurPlane = reader.ReadSingle();
            }
            
            dofFarBlurLimit = reader.ReadSingle();
            dofBlurScale = reader.ReadSingle();

            if (EnvFunctions.envVersionCheck > 0x1105000)
            {
                dofGaussType = reader.ReadUInt32();
            }

            enableSSAO = reader.ReadByte();
            ssaoOccluderRadius = reader.ReadSingle();
            ssaoFallOffRadius = reader.ReadSingle();
            ssaoBlurScale = reader.ReadSingle();
            ssaoBrightness = reader.ReadSingle();
            ssaoDepthRange = reader.ReadSingle();

            disableUnknownFlaggedSection = reader.ReadByte();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(field1F1);
            writer.WriteSingle(field1F2);

            if (EnvFunctions.envVersionCheck != 0x1104910)
            {
                writer.WriteSingle(diffFilterStrength);
            }
            else
            {
                writer.WriteByte(field1F6);
                writer.WriteByte(field1F7);
                writer.WriteByte(field1F8);
                writer.WriteByte(field1F9);
            }

            writer.WriteSingle(field1FA);

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1105040)
            {
                writer.WriteByte(enableDOF);
                writer.WriteSingle(dofFocalPlane);
                writer.WriteSingle(dofNearBlurPlane);
                writer.WriteSingle(dofFarBlurPlane);
            }

            writer.WriteSingle(dofFarBlurLimit);
            writer.WriteSingle(dofBlurScale);

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1105000)
            {
                writer.WriteUInt32(dofGaussType);
            }

            writer.WriteByte(enableSSAO);
            writer.WriteSingle(ssaoOccluderRadius);
            writer.WriteSingle(ssaoFallOffRadius);
            writer.WriteSingle(ssaoBlurScale);
            writer.WriteSingle(ssaoBrightness);
            writer.WriteSingle(ssaoDepthRange);

            writer.WriteByte(disableUnknownFlaggedSection);
        }
    }
}
