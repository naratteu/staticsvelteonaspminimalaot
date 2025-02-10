using System.Runtime.InteropServices;

namespace SvelteApp.Server;

static class WebUI
{
    const string DLL = "webui-2-static";
    const CallingConvention Cdecl = CallingConvention.Cdecl;
    [DllImport(DLL, CallingConvention = Cdecl)] public static extern UIntPtr webui_new_window();
    [DllImport(DLL, CallingConvention = Cdecl)][return: MarshalAs(UnmanagedType.I1)] public static extern bool webui_show(UIntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string content);
    [DllImport(DLL, CallingConvention = Cdecl)] public static extern void webui_wait();
}