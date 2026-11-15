using Amicitia.IO.Binary;

namespace P5ENVEditor.Env
{
    public struct EnvHeader
    {
        public uint fileMagic;
        public uint gfsVersion;
        public uint fileType;
        public uint Field0C; //padding?

        public EnvHeader(BinaryObjectReader reader)
        {
            fileMagic = reader.ReadUInt32();
            gfsVersion = reader.ReadUInt32();
            fileType = reader.ReadUInt32();
            Field0C = reader.ReadUInt32();
        }

        public void WriteHeader(BinaryObjectWriter writer)
        {
            writer.WriteUInt32(fileMagic);
            writer.WriteUInt32(gfsVersion);
            writer.WriteUInt32(fileType);
            writer.WriteUInt32(Field0C);
        }
    }
}
