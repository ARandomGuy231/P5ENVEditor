using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct FieldModelSection
    {
        public byte field0010; //extra byte at location 0010h
        public byte enableFieldModelSection;

        public float fieldModelAmbientR;
        public float fieldModelAmbientG;
        public float fieldModelAmbientB;
        public float fieldModelAmbientA;

        public float fieldModelDiffuseR;
        public float fieldModelDiffuseG;
        public float fieldModelDiffuseB;
        public float fieldModelDiffuseA;

        public float fieldModelSpecularR;
        public float fieldModelSpecularG;
        public float fieldModelSpecularB;
        public float fieldModelSpecularA;

        public float fieldModelEmissiveR;
        public float fieldModelEmissiveG;
        public float fieldModelEmissiveB;
        public float fieldModelEmissiveA;

        public float field52;
        public float field56;
        public float field5A;
        public float field5E;

        public float fieldModelLightX;
        public float fieldModelLightY;
        public float fieldModelLightZ;

        public byte[] unusedTextureAdjustmentSection;

        public FieldModelSection(BinaryObjectReader reader)
        {
            field0010 = reader.ReadByte();
            enableFieldModelSection = reader.ReadByte();

            fieldModelAmbientR = reader.ReadSingle();
            fieldModelAmbientG = reader.ReadSingle();
            fieldModelAmbientB = reader.ReadSingle();
            fieldModelAmbientA = reader.ReadSingle();

            fieldModelDiffuseR = reader.ReadSingle();
            fieldModelDiffuseG = reader.ReadSingle();
            fieldModelDiffuseB = reader.ReadSingle();
            fieldModelDiffuseA = reader.ReadSingle();

            fieldModelSpecularR = reader.ReadSingle();
            fieldModelSpecularG = reader.ReadSingle();
            fieldModelSpecularB = reader.ReadSingle();
            fieldModelSpecularA = reader.ReadSingle();

            fieldModelEmissiveR = reader.ReadSingle();
            fieldModelEmissiveG = reader.ReadSingle();
            fieldModelEmissiveB = reader.ReadSingle();
            fieldModelEmissiveA = reader.ReadSingle();

            field52 = reader.ReadSingle();
            field56 = reader.ReadSingle();
            field5A = reader.ReadSingle();
            field5E = reader.ReadSingle();

            fieldModelLightX = reader.ReadSingle();
            fieldModelLightY = reader.ReadSingle();
            fieldModelLightZ = reader.ReadSingle();

            unusedTextureAdjustmentSection = reader.ReadArray<byte>(188);
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(field0010);
            writer.WriteByte(enableFieldModelSection);

            writer.WriteSingle(fieldModelAmbientR);
            writer.WriteSingle(fieldModelAmbientG);
            writer.WriteSingle(fieldModelAmbientB);
            writer.WriteSingle(fieldModelAmbientA);

            writer.WriteSingle(fieldModelDiffuseR);
            writer.WriteSingle(fieldModelDiffuseG);
            writer.WriteSingle(fieldModelDiffuseB);
            writer.WriteSingle(fieldModelDiffuseA);

            writer.WriteSingle(fieldModelSpecularR);
            writer.WriteSingle(fieldModelSpecularG);
            writer.WriteSingle(fieldModelSpecularB);
            writer.WriteSingle(fieldModelSpecularA);

            writer.WriteSingle(fieldModelEmissiveR);
            writer.WriteSingle(fieldModelEmissiveG);
            writer.WriteSingle(fieldModelEmissiveB);
            writer.WriteSingle(fieldModelEmissiveA);

            writer.WriteSingle(field52);
            writer.WriteSingle(field56);
            writer.WriteSingle(field5A);
            writer.WriteSingle(field5E);

            writer.WriteSingle(fieldModelLightX);
            writer.WriteSingle(fieldModelLightY);
            writer.WriteSingle(fieldModelLightZ);

            writer.WriteBytes(unusedTextureAdjustmentSection);
        }
    }
}
