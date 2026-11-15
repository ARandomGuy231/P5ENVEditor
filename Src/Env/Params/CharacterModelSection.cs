using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct CharacterModelSection
    {
        public byte field0120; //extra byte at location 0120h
        public byte enableCharacterModelSection;

        public float characterModelAmbientR;
        public float characterModelAmbientG;
        public float characterModelAmbientB;
        public float characterModelAmbientA;

        //also affects rim lighting
        public float characterModelDiffuseR;
        public float characterModelDiffuseG;
        public float characterModelDiffuseB;
        public float characterModelDiffuseA;

        public float characterModelSpecularR;
        public float characterModelSpecularG;
        public float characterModelSpecularB;
        public float characterModelSpecularA;

        public float characterModelEmissiveR;
        public float characterModelEmissiveG;
        public float characterModelEmissiveB;
        public float characterModelEmissiveA;

        public float field16C;
        public float field170;
        public float field174;
        public float field178;

        public float characterModelLightX;
        public float characterModelLightY;
        public float characterModelLightZ;

        //here onwards include in a camera tab, like in the beta
        public float cameraFOV; //camera fov 1-179 (was field188), two decimal places.
        public float modelNearClip; //two decimal places.
        public float modelFarClip; //two decimal places.

        public CharacterModelSection(BinaryObjectReader reader)
        {
            field0120 = reader.ReadByte();
            enableCharacterModelSection = reader.ReadByte();

            characterModelAmbientR = reader.ReadSingle();
            characterModelAmbientG = reader.ReadSingle();
            characterModelAmbientB = reader.ReadSingle();
            characterModelAmbientA = reader.ReadSingle();

            characterModelDiffuseR = reader.ReadSingle();
            characterModelDiffuseG = reader.ReadSingle();
            characterModelDiffuseB = reader.ReadSingle();
            characterModelDiffuseA = reader.ReadSingle();

            characterModelSpecularR = reader.ReadSingle();
            characterModelSpecularG = reader.ReadSingle();
            characterModelSpecularB = reader.ReadSingle();
            characterModelSpecularA = reader.ReadSingle();

            characterModelEmissiveR = reader.ReadSingle();
            characterModelEmissiveG = reader.ReadSingle();
            characterModelEmissiveB = reader.ReadSingle();
            characterModelEmissiveA = reader.ReadSingle();

            field16C = reader.ReadSingle();
            field170 = reader.ReadSingle();
            field174 = reader.ReadSingle();
            field178 = reader.ReadSingle();

            characterModelLightX = reader.ReadSingle();
            characterModelLightY = reader.ReadSingle();
            characterModelLightZ = reader.ReadSingle();

            cameraFOV = reader.ReadSingle();
            modelNearClip = reader.ReadSingle();
            modelFarClip = reader.ReadSingle();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(field0120);
            writer.WriteByte(enableCharacterModelSection);

            writer.WriteSingle(characterModelAmbientR);
            writer.WriteSingle(characterModelAmbientG);
            writer.WriteSingle(characterModelAmbientB);
            writer.WriteSingle(characterModelAmbientA);

            writer.WriteSingle(characterModelDiffuseR);
            writer.WriteSingle(characterModelDiffuseG);
            writer.WriteSingle(characterModelDiffuseB);
            writer.WriteSingle(characterModelDiffuseA);

            writer.WriteSingle(characterModelSpecularR);
            writer.WriteSingle(characterModelSpecularG);
            writer.WriteSingle(characterModelSpecularB);
            writer.WriteSingle(characterModelSpecularA);

            writer.WriteSingle(characterModelEmissiveR);
            writer.WriteSingle(characterModelEmissiveG);
            writer.WriteSingle(characterModelEmissiveB);
            writer.WriteSingle(characterModelEmissiveA);

            writer.WriteSingle(field16C);
            writer.WriteSingle(field170);
            writer.WriteSingle(field174);
            writer.WriteSingle(field178);

            writer.WriteSingle(characterModelLightX);
            writer.WriteSingle(characterModelLightY);
            writer.WriteSingle(characterModelLightZ);

            writer.WriteSingle(cameraFOV);
            writer.WriteSingle(modelNearClip);
            writer.WriteSingle(modelFarClip);
        }
    }
}
