using Localization.Plugin.Plugins;

namespace Localization.Plugin
{
    public static class PluginManager
    {
        private static IPlugin? csPlugin = null;
        private static IPlugin? hcppPlugin = null;
        private static IPlugin? hppCppPlugin = null;
        private static IPlugin? hInlinePlugin = null;
        private static IPlugin? hppInlinePlugin = null;

        public static Plugin? GetDefaultPlugin(EPlugin pluginType)
        {
            IPlugin? plugin = null;

            switch (pluginType)
            {
                case EPlugin.CS:
                    if (csPlugin == null)
                    {
                        csPlugin = new CS_Plugin();
                    }
                    plugin = csPlugin;
                    break;

                case EPlugin.H_CPP:
                    if (hcppPlugin == null)
                    {
                        hcppPlugin = new H_CPP_Plugin();
                    }
                    plugin = hcppPlugin;
                    break;

                case EPlugin.HPP_CPP:
                    if (hppCppPlugin == null)
                    {
                        hppCppPlugin = new HPP_CPP_Plugin();
                    }
                    plugin = hppCppPlugin;
                    break;

                case EPlugin.HInline:
                    if (hInlinePlugin == null)
                    {
                        hInlinePlugin = new H_Inline_Plugin();
                    }
                    plugin = hInlinePlugin;
                    break;

                case EPlugin.HPPInline:
                    if (hppInlinePlugin == null)
                    {
                        hppInlinePlugin = new HPP_Inline_Plugin();
                    }
                    plugin = hppInlinePlugin;
                    break;

                default:
                    break;
            }

            if (plugin != null)
            {
                return plugin as Plugin;
            }

            return null;
        }
    }
}