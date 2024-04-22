/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

// Copyright (C) 2016 Google, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if UNITY_ANDROID

using System;

using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
    public class NativeExpressAdClient : AndroidJavaProxy, INativeExpressAdClient
    {
        private AndroidJavaObject nativeExpressAdView;

        public NativeExpressAdClient() : base(Utils.UnityAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.nativeExpressAdView = new AndroidJavaObject(
                Utils.NativeExpressAdViewClassName, activity, this);
        }

        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Creates a native express ad view.
        public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, AdPosition position)
        {
            this.nativeExpressAdView.Call(
                    "create",
                    new object[3] { adUnitId, Utils.GetAdSizeJavaObject(adSize), (int)position });
        }

        // Creates a native express ad view with a custom position
        public void CreateNativeExpressAdView(string adUnitId, AdSize adSize, int x, int y)
        {
            this.nativeExpressAdView.Call(
                "create",
                new object[4] { adUnitId, Utils.GetAdSizeJavaObject(adSize), x, y });
        }

        // Loads an ad.
        public void LoadAd(AdRequest request)
        {
            this.nativeExpressAdView.Call("loadAd", Utils.GetAdRequestJavaObject(request));
        }

        // Set the ad size for the native express ad view.
        public void SetAdSize(AdSize adSize)
        {
            this.nativeExpressAdView.Call("setAdSize", Utils.GetAdSizeJavaObject(adSize));
        }

        // Displays the native express ad view on the screen.
        public void ShowNativeExpressAdView()
        {
            this.nativeExpressAdView.Call("show");
        }

        // Hides the native express ad view from the screen.
        public void HideNativeExpressAdView()
        {
            this.nativeExpressAdView.Call("hide");
        }

        // Destroys the native express ad view.
        public void DestroyNativeExpressAdView()
        {
            this.nativeExpressAdView.Call("destroy");
        }

        // Returns the mediation adapter class name.
        public string MediationAdapterClassName()
        {
            return this.nativeExpressAdView.Call<string>("getMediationAdapterClassName");
        }

#region Callbacks from UnityAdListener.

        public void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }

        public void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }

        public void onAdOpened()
        {
            if (this.OnAdOpening != null)
            {
                this.OnAdOpening(this, EventArgs.Empty);
            }
        }

        public void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }

        public void onAdLeftApplication()
        {
            if (this.OnAdLeavingApplication != null)
            {
                this.OnAdLeavingApplication(this, EventArgs.Empty);
            }
        }

#endregion
    }
}

#endif