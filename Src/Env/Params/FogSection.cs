using Amicitia.IO.Binary;

namespace P5ENVEditor.Env.Params
{
    public struct FogSection
    {
        public byte enableFog;
        public byte enableAmbientFog;
        public byte fogMode; //According to the beta: 0 = linear, 1 = exponential and 2 = exponential2. Called disableFog in the 010 template.
        public byte toggleFogCameraPlane;
        public float fogStartDistance; //two decimal places.
        public float fogEndDistance; //two decimal places.
        public float fogRed;
        public float fogGreen;
        public float fogBlue;
        public float fogOpacity;

        public byte enableFloorFog;
        public float floorFogStartHeight; //two decimal places.
        public float floorFogEndHeight; //two decimal places.
        public float floorFogRed;
        public float floorFogGreen;
        public float floorFogBlue;
        public float floorFogOpacity;

        public FogSection(BinaryObjectReader reader)
        {
            enableFog = reader.ReadByte();
            enableAmbientFog = reader.ReadByte();
            fogMode = reader.ReadByte();
            toggleFogCameraPlane = reader.ReadByte();
            fogStartDistance = reader.ReadSingle();
            fogEndDistance = reader.ReadSingle();
            fogRed = reader.ReadSingle();
            fogGreen = reader.ReadSingle();
            fogBlue = reader.ReadSingle();
            fogOpacity = reader.ReadSingle();

            enableFloorFog = reader.ReadByte();
            floorFogStartHeight = reader.ReadSingle();
            floorFogEndHeight = reader.ReadSingle();
            floorFogRed = reader.ReadSingle();
            floorFogGreen = reader.ReadSingle();
            floorFogBlue = reader.ReadSingle();
            floorFogOpacity = reader.ReadSingle();
        }

        public void Write(BinaryObjectWriter writer)
        {
            writer.WriteByte(enableFog);
            writer.WriteByte(enableAmbientFog);
            writer.WriteByte(fogMode);
            writer.WriteByte(toggleFogCameraPlane);
            writer.WriteSingle(fogStartDistance);
            writer.WriteSingle(fogEndDistance);
            writer.WriteSingle(fogRed);
            writer.WriteSingle(fogGreen);
            writer.WriteSingle(fogBlue);
            writer.WriteSingle(fogOpacity);

            writer.WriteByte(enableFloorFog);
            writer.WriteSingle(floorFogStartHeight);
            writer.WriteSingle(floorFogEndHeight);
            writer.WriteSingle(floorFogRed);
            writer.WriteSingle(floorFogGreen);
            writer.WriteSingle(floorFogBlue);
            writer.WriteSingle(floorFogOpacity);
        }
    }
}
