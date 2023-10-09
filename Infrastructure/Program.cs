// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// 与えられた IP アドレスの文字列のサブネットマスクを返すメソッド
string GetSubnetMask(string ipAddress)
{
    // IP アドレスの文字列をバイト配列に変換する
    var ipAddressBytes = ipAddress.Split('.').Select(s => byte.Parse(s)).ToArray();
    // サブネットマスクのバイト配列を用意する
    var subnetMaskBytes = new byte[ipAddressBytes.Length];
    // サブネットマスクのバイト配列を作成する
    for (int i = 0; i < ipAddressBytes.Length; i++)
    {
        // バイト配列の要素の値を取得する
        var ipAddressByte = ipAddressBytes[i];
        // バイト配列の要素の値をビット反転する
        var subnetMaskByte = (byte)~ipAddressByte;
        // バイト配列の要素の値を格納する
        subnetMaskBytes[i] = subnetMaskByte;
    }
    // サブネットマスクのバイト配列を文字列に変換する
    var subnetMask = string.Join(".", subnetMaskBytes);
    // サブネットマスクを返す
    return subnetMask;
}







