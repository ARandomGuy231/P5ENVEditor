using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct SecondUnknownSection
    {
        public float lightMapR;
        public float lightMapG;
        public float lightMapB;
        public float lightMapA;

        public byte enableCharacterOutlines;
        public float characterOutlineOpacity; //outline range, controls how far from the camera outlines appear, which can make them look thicker, two decimal places. 0-9999 (setting to 0 disables outlines)
        public float characterOutlineWidth;
        public float field27A; //only used below 0x1104940
        public float characterOutlineBrightness; //correct but acts more like opacity, goes from 0-1, two decimal places.

        public float field2F2; //outline start 0-2000, two decimal places.
        public float field2F6; //outline end 0-2000, two decimal places.
        public float reflectionHeight; //water surface height according to beta, two decimal places.

        public float field284; //only in 0x1104970

        public SecondUnknownSection(BinaryObjectReader reader)
        {
            lightMapR = reader.ReadSingle();
            lightMapG = reader.ReadSingle();
            lightMapB = reader.ReadSingle();
            lightMapA = reader.ReadSingle();

            enableCharacterOutlines = reader.ReadByte();
            characterOutlineOpacity = reader.ReadSingle();
            characterOutlineWidth = reader.ReadSingle();

            if (EnvFunctions.envVersionCheck > 0x1104940)
            {
                characterOutlineBrightness = reader.ReadSingle();
            }
            else
            {
                field27A = reader.ReadSingle();
            }

            if (EnvFunctions.envVersionCheck > 0x1104970)
            {
                field2F2 = reader.ReadSingle();

                if (EnvFunctions.envVersionCheck != 0x1105020 && enableCharacterOutlines == 1)
                {
                    field2F6 = reader.ReadSingle();
                    reflectionHeight = reader.ReadSingle();
                }
            }
            else if (EnvFunctions.envVersionCheck == 0x1104970)
            {
                field284 = reader.ReadSingle();
            }
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteSingle(lightMapR);
            writer.WriteSingle(lightMapG);
            writer.WriteSingle(lightMapB);
            writer.WriteSingle(lightMapA);

            writer.WriteByte(enableCharacterOutlines);
            writer.WriteSingle(characterOutlineOpacity);
            writer.WriteSingle(characterOutlineWidth);

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1104940)
            {
                writer.WriteSingle(characterOutlineBrightness);
            }
            else
            {
                writer.WriteSingle(field27A);
            }

            if (EnvFunctions.loadedENVHeader.gfsVersion > 0x1104970)
            {
                writer.WriteSingle(field2F2);

                if (EnvFunctions.loadedENVHeader.gfsVersion != 0x1105020 && enableCharacterOutlines == 1)
                {
                    writer.WriteSingle(field2F6);
                    writer.WriteSingle(reflectionHeight);
                }
            }
            else if (EnvFunctions.envVersionCheck == 0x1104970)
            {
                writer.WriteSingle(field284);
            }
        }
    }
}
