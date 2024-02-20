namespace LessonsManagmentService.Core.Data;

public interface IQrCodeGeneratorClient
{
    public Task<byte[]> GenerateQrCodeAsync(string data);
}