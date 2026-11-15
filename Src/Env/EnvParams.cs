using Amicitia.IO.Binary;
using P5ENVEditor.Env.Params;

namespace P5ENVEditor.Env
{
    public struct EnvParams
    {
        public FieldModelSection fieldModelSection;
        public CharacterModelSection characterModelSection;
        public FogSection fogSection;
        public LightingSection lightingSection;
        public UnknownSection unknownSection;
        public FieldShadowSection fieldShadowSection;
        public ColorCorrectionSection colorCorrectionSection;
        public SecondUnknownSection secondUnknownSection;
        public PhysicsSection physicsSection;
        public SkyColorSection skyColorSection;

        public EnvParams(BinaryObjectReader reader)
        {
            fieldModelSection = new FieldModelSection(reader);
            characterModelSection = new CharacterModelSection(reader);
            fogSection = new FogSection(reader);
            lightingSection = new LightingSection(reader);
            unknownSection = new UnknownSection(reader);
            fieldShadowSection = new FieldShadowSection(reader);
            colorCorrectionSection = new ColorCorrectionSection(reader);
            secondUnknownSection = new SecondUnknownSection(reader);
            physicsSection = new PhysicsSection(reader);
            skyColorSection = new SkyColorSection(reader);
        }

        public void WriteParams(BinaryObjectWriter writer)
        {
            fieldModelSection.Write(writer);
            characterModelSection.Write(writer);
            fogSection.Write(writer);
            lightingSection.Write(writer);
            unknownSection.Write(writer);
            fieldShadowSection.Write(writer);
            colorCorrectionSection.Write(writer);
            secondUnknownSection.Write(writer);
            physicsSection.Write(writer);
            skyColorSection.Write(writer);
        }
    }
}
