﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18033
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Splicer.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Splicer.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 Audio Input 的本地化字符串。
        /// </summary>
        internal static string AudioInputPinNamePrefix {
            get {
                return ResourceManager.GetString("AudioInputPinNamePrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ASF Writer 的本地化字符串。
        /// </summary>
        internal static string DefaultAsfWriterName {
            get {
                return ResourceManager.GetString("DefaultAsfWriterName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Output File 的本地化字符串。
        /// </summary>
        internal static string DefaultFileDestinationName {
            get {
                return ResourceManager.GetString("DefaultFileDestinationName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Null Renderer 的本地化字符串。
        /// </summary>
        internal static string DefaultNullRendererName {
            get {
                return ResourceManager.GetString("DefaultNullRendererName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Video Rendering Window 的本地化字符串。
        /// </summary>
        internal static string DefaultVideoRenderingWindowCaption {
            get {
                return ResourceManager.GetString("DefaultVideoRenderingWindowCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Wav DEST 的本地化字符串。
        /// </summary>
        internal static string DefaultWavDestinationName {
            get {
                return ResourceManager.GetString("DefaultWavDestinationName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The supplied async result was not issued by this instance 的本地化字符串。
        /// </summary>
        internal static string ErrorAsyncResultNotIssuesByThisInstance {
            get {
                return ResourceManager.GetString("ErrorAsyncResultNotIssuesByThisInstance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You can not cancel this renderer, it is already completing/canceling 的本地化字符串。
        /// </summary>
        internal static string ErrorAttemptToCancelWhenCancelingOrCompleting {
            get {
                return ResourceManager.GetString("ErrorAttemptToCancelWhenCancelingOrCompleting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You can not cancel, a request to cancel has already been issued - have you remembered to call EndCancel? 的本地化字符串。
        /// </summary>
        internal static string ErrorAttemptToCancelWhenCancelInProgress {
            get {
                return ResourceManager.GetString("ErrorAttemptToCancelWhenCancelInProgress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Can not render to AVI when no video group exists 的本地化字符串。
        /// </summary>
        internal static string ErrorCanNotRenderAviWhenNoVideoGroupExists {
            get {
                return ResourceManager.GetString("ErrorCanNotRenderAviWhenNoVideoGroupExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Can not resolve media type for encoder ({0} khz, {1} kbps, mono? {2}) - list of available formats follow: 的本地化字符串。
        /// </summary>
        internal static string ErrorCanNotResolveMediaTypeForEncoder {
            get {
                return ResourceManager.GetString("ErrorCanNotResolveMediaTypeForEncoder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Can not resolve audio encoder &quot;{0}&quot; 的本地化字符串。
        /// </summary>
        internal static string ErrorCanResolveAudioEncoder {
            get {
                return ResourceManager.GetString("ErrorCanResolveAudioEncoder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You can not add audio clips to a track which exists within a non-audio group 的本地化字符串。
        /// </summary>
        internal static string ErrorCantAddAudioClipsToVideoGroup {
            get {
                return ResourceManager.GetString("ErrorCantAddAudioClipsToVideoGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You can not add video or image clips to a track which exists within a non-video group 的本地化字符串。
        /// </summary>
        internal static string ErrorCantAddVideoClipsToAudioGroup {
            get {
                return ResourceManager.GetString("ErrorCantAddVideoClipsToAudioGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 EndCancel has already been called fo this async result 的本地化字符串。
        /// </summary>
        internal static string ErrorEndCancelAlreadyCalledForAsyncResult {
            get {
                return ResourceManager.GetString("ErrorEndCancelAlreadyCalledForAsyncResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 EndRender has already been called for this async result 的本地化字符串。
        /// </summary>
        internal static string ErrorEndRenderAlreadyCalledForAsyncResult {
            get {
                return ResourceManager.GetString("ErrorEndRenderAlreadyCalledForAsyncResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Exception occurred while attempting to cancel render request, see inner exception for details 的本地化字符串。
        /// </summary>
        internal static string ErrorExceptionOccuredDuringCancelRenderRequest {
            get {
                return ResourceManager.GetString("ErrorExceptionOccuredDuringCancelRenderRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Exception occurred while attempting to render, see inner exception for details 的本地化字符串。
        /// </summary>
        internal static string ErrorExceptionOccuredDuringRenderRequest {
            get {
                return ResourceManager.GetString("ErrorExceptionOccuredDuringRenderRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Frames per second must be greater then 0 的本地化字符串。
        /// </summary>
        internal static string ErrorFramesPerSecondMustBeGreaterThenZero {
            get {
                return ResourceManager.GetString("ErrorFramesPerSecondMustBeGreaterThenZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Graph not yet started 的本地化字符串。
        /// </summary>
        internal static string ErrorGraphNotYetStarted {
            get {
                return ResourceManager.GetString("ErrorGraphNotYetStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Groups are top level timeline components and do not support this property 的本地化字符串。
        /// </summary>
        internal static string ErrorGroupsDontSupportContainerProperty {
            get {
                return ResourceManager.GetString("ErrorGroupsDontSupportContainerProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Invalid length specified 的本地化字符串。
        /// </summary>
        internal static string ErrorInvalidLengthSpecified {
            get {
                return ResourceManager.GetString("ErrorInvalidLengthSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Output file name is null or invalid 的本地化字符串。
        /// </summary>
        internal static string ErrorInvalidOutputFileName {
            get {
                return ResourceManager.GetString("ErrorInvalidOutputFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You must call BeginCancel before EndCancel 的本地化字符串。
        /// </summary>
        internal static string ErrorMustCallBeginCancelBeforeEndCancel {
            get {
                return ResourceManager.GetString("ErrorMustCallBeginCancelBeforeEndCancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You must call BeginRender before EndRender 的本地化字符串。
        /// </summary>
        internal static string ErrorMustCallBeginRenderBeforeEndRender {
            get {
                return ResourceManager.GetString("ErrorMustCallBeginRenderBeforeEndRender", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 No audio group to render 的本地化字符串。
        /// </summary>
        internal static string ErrorNoAudioStreamToRender {
            get {
                return ResourceManager.GetString("ErrorNoAudioStreamToRender", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 No group found supporting a clip of type &quot;{0}&quot; 的本地化字符串。
        /// </summary>
        internal static string ErrorNoGroupForSupportingClipOfType {
            get {
                return ResourceManager.GetString("ErrorNoGroupForSupportingClipOfType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 No tracks found in the first group of type &quot;{0}&quot; 的本地化字符串。
        /// </summary>
        internal static string ErrorNoTracksFoundInFirstGroupOfType {
            get {
                return ResourceManager.GetString("ErrorNoTracksFoundInFirstGroupOfType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 pins enumerator is null 的本地化字符串。
        /// </summary>
        internal static string ErrorPinsEnumeratorIsNull {
            get {
                return ResourceManager.GetString("ErrorPinsEnumeratorIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 A previous render request has not yet been completed - have you remembered to call EndRender? 的本地化字符串。
        /// </summary>
        internal static string ErrorPreviousRenderRequestInProgress {
            get {
                return ResourceManager.GetString("ErrorPreviousRenderRequestInProgress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The render request was canceled by the user 的本地化字符串。
        /// </summary>
        internal static string ErrorRenderRequestCanceledByUser {
            get {
                return ResourceManager.GetString("ErrorRenderRequestCanceledByUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unrecognized bit format 的本地化字符串。
        /// </summary>
        internal static string ErrorUnrecognizedBitFormat {
            get {
                return ResourceManager.GetString("ErrorUnrecognizedBitFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The selected windows media profile encodes audio information, yet no audio group exists 的本地化字符串。
        /// </summary>
        internal static string ErrorWMProfileRequiresAudioGroup {
            get {
                return ResourceManager.GetString("ErrorWMProfileRequiresAudioGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The selected windows media profile encodes video information, yet no video group exists 的本地化字符串。
        /// </summary>
        internal static string ErrorWMProfileRequiresVideoGroup {
            get {
                return ResourceManager.GetString("ErrorWMProfileRequiresVideoGroup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 frame{0}.jpg 的本地化字符串。
        /// </summary>
        internal static string ImagesToDiskParticipantFilenameTemplate {
            get {
                return ResourceManager.GetString("ImagesToDiskParticipantFilenameTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Media Event Thread 的本地化字符串。
        /// </summary>
        internal static string MediaEventThreadName {
            get {
                return ResourceManager.GetString("MediaEventThreadName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Mono 的本地化字符串。
        /// </summary>
        internal static string Mono {
            get {
                return ResourceManager.GetString("Mono", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Direction: {0}, Name: {1}, QueryId: {2} 的本地化字符串。
        /// </summary>
        internal static string PinQueryInfoTemplate {
            get {
                return ResourceManager.GetString("PinQueryInfoTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Stereo 的本地化字符串。
        /// </summary>
        internal static string Stereo {
            get {
                return ResourceManager.GetString("Stereo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 splicerTempAudio{0}{1} 的本地化字符串。
        /// </summary>
        internal static string TemporaryAudioFilenameTemplate {
            get {
                return ResourceManager.GetString("TemporaryAudioFilenameTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 splicerTempImage{0}.bmp 的本地化字符串。
        /// </summary>
        internal static string TemporaryImageFilenameTemplate {
            get {
                return ResourceManager.GetString("TemporaryImageFilenameTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unsupported AMMEdiaType encountered 的本地化字符串。
        /// </summary>
        internal static string UnsupportedAMMEdiaType {
            get {
                return ResourceManager.GetString("UnsupportedAMMEdiaType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Video Input 的本地化字符串。
        /// </summary>
        internal static string VideoInputPinNamePrefix {
            get {
                return ResourceManager.GetString("VideoInputPinNamePrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;clip start=&quot;{0}&quot; stop=&quot;{1}&quot; src=&quot;{2}&quot; mstart=&quot;{3}&quot; /&gt; 的本地化字符串。
        /// </summary>
        internal static string VirtualClipToStringTemplate {
            get {
                return ResourceManager.GetString("VirtualClipToStringTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0:0.000}s 的本地化字符串。
        /// </summary>
        internal static string WatermarkTimeStamp {
            get {
                return ResourceManager.GetString("WatermarkTimeStamp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 {0} - {1} kHz - {2} kbps 的本地化字符串。
        /// </summary>
        internal static string WavFormatInfoTemplate {
            get {
                return ResourceManager.GetString("WavFormatInfoTemplate", resourceCulture);
            }
        }
    }
}
