using System;
using System.Collections.Generic;
using HeartbeatSharp.Core;
using HeartbeatSharp.Endpoints;

AuthenticatedHeartbeatApi api = new("secret token here","https://hb.metacinna.bar/api");

await api.Beat("heartbeat-sharp");

ApiResponse<Stats> statsResponse = await api.GetStats();

if (statsResponse.Success)
{
    Stats stats = statsResponse.Data;
    Console.WriteLine("Total beats for Metacinnabar: " + stats.TotalBeats);
}
else
{
    Console.WriteLine("[error] failed to get request stats endpoint");
}

ApiResponse<List<Device>> devicesResponse = await api.GetDevices();

if (devicesResponse.Success)
{
    List<Device> devices = devicesResponse.Data!;

    foreach (Device device in devices)
    {
        Console.WriteLine("Device found: " + device.DeviceName);
    }
}
else
{
    Console.WriteLine("[error] failed to get request devices endpoint");
}