# Cloudy Crash Reporting

A playground for testing out different cloud services with regards to crashes and exceptions.

## Overview

Below is a matrix of the cloud services, SDK features and platforms. Clicking the cloud service name will take you to a
more detailed section of the service. I have also attached notes to various parts for more information.

> NOTE: The order of the services are alphabetical and are not a ranking or suggestion of preferred cloud provider.

|                   Cloud Service | Android | iOS |    macOS     | Windows |    Tizen     |  .NET MAUI   |   .NET Ex    |  Native Ex   |
|--------------------------------:|:-------:|:---:|:------------:|:-------:|:------------:|:------------:|:------------:|:------------:|
|         [**DataDog**](#datadog) |    ✅    |  ✅  |      ❌       |    ❌    |      ❌       |      ❌       | ❌ [[5]](#n5) | ➗ [[6]](#n6) |
|     [**Dynatrace**](#dynatrace) |    ✅    |  ✅  |      ❌       |    ❌    |      ❌       |      ✅       |      ✅       |      ✅       |
| [**Firebase Crashlytics**](#fb) |    ✅    |  ✅  | ❌ [[4]](#n4) |    ❌    |      ❌       | ➗ [[7]](#n7) | ➗ [[3]](#n3) |      ✅       |
|     [**New Relic**](#new-relic) |    ✅    |  ✅  |      ❌       |    ❌    |      ❌       |      ✅       |      ✅       | ➗ [[1]](#n1) |
|           [**Raygun**](#raygun) |    ✅    |  ✅  |      ✅       |    ✅    | ➗ [[8]](#n8) |      ✅       |      ✅       | ➗ [[9]](#n9) |
|      [**Sentry.io**](#sentryio) |    ✅    |  ✅  |      ✅       |    ✅    | ➗ [[2]](#n2) |      ✅       |      ✅       |      ✅       |
|    **Visual Studio App Center** |    ➖    |  ➖  |      ➖       |    ➖    |      ➖       |      ➖       |      ➖       |      ➖       |

> **Key**  
> ✅ → fully supported  
> ➗ → partially supported, see notes  
> ❌ → not supported at all  
> ➖ → unknown / yet to be determined  

### Notes

1. <a name="n1"></a> **[New Relic]** Android native crash reporting is still in development and actually is not enabled
   for .NET MAUI Android apps: https://docs.newrelic.com/docs/mobile-monitoring/mobile-monitoring-ui/crashes/investigate-mobile-app-crash-report/#android-native-reporting
2. <a name="n2"></a> **[Sentry.io]** There is no explicit native Tizen SDK for Sentry, however the .NET SDK does have
   support for all .NET frameworks, which includes the Tizen .NET SDK.
3. <a name="n3"></a> **[Firebase Crashlytics]** There is no support for capturing .NET exceptions because the SDK is
   purely native. However, since .NET exceptions will crash the app, the crash is still reported using the native stack
   traces - which may include the .NET stack trace and potentially information from the .NET runtime.
4. <a name="n4"></a> **[Firebase Crashlytics]** The Firebase SDK from Google supports macOS and Mac Catalyst, but the
   Xamarin bindings currently do not expose this: https://github.com/xamarin/GoogleApisForiOSComponents/issues/516
5. <a name="n5"></a> **[DataDog]** There are no .NET bindings for .NET mobile frameworks, so I am unable to determine
   the level of support for .NET applications, however, based on other SDKs that use .NET bindings there should be some 
   level of usability. For example, Firebase Crashlytics is only a binding but can report some .NET exceptions.
6. <a name="n6"></a> **[DataDog]** There is no .NET bindings for .NET mobile frameworks, so I am unable to determine
   the level of support for native exceptions. However, the docs and SDK do indicate that this is supported.
7. <a name="n7"></a> **[Firebase Crashlytics]** There is no official .NET MAUI SDK, but there is a community plugin for
   Android and iOS: https://github.com/TobiasBuchholz/Plugin.Firebase
8. <a name="n8"></a> **[Raygun]** There is no explicit native Tizen SDK, however the .NET SDK does have support for all
   .NET frameworks, which includes the Tizen .NET SDK.
9. <a name="n9"></a> **[Raygun]** The docs state native crash reporting and there is some for Android, however iOS does
   does not seem to do anything: https://github.com/MindscapeHQ/raygun4maui/issues/13


## Types of Crashes & Exceptions

In a mobile or desktop app, there are a few types of issues that can cause catastrophic failure:

* Native code failures/exceptions
* Unhandled exceptions in .NET/managed code
* Exception reporting for handled exceptions

## Cloud Services

### DataDog

> SUPPORT: Currently there is no official or community bindings for the SDKs, so I opened issues to find out.  
> Android: https://github.com/DataDog/dd-sdk-android/issues/1811
> iOS: https://github.com/DataDog/dd-sdk-ios/issues/1617

**Links:**

* Home: https://www.datadoghq.com/
* .NET MAUI: There is no official or community support for .NET mobile frameworks.

**Pros:**

* Open source:
  * Android: https://github.com/DataDog/dd-sdk-android
  * iOS: https://github.com/DataDog/dd-sdk-ios

**Cons:**

* No .NET mobile bindings so not really usable in a .NET MAUI app - or any .NET mobile app


### Dynatrace

**Links:**

* Home: https://www.dynatrace.com
* .NET MAUI: https://docs.dynatrace.com/docs/platform-modules/digital-experience/mobile-applications/development-frameworks/maui

**Pros:**

* Native crash reporting for Android and iOS

**Cons:**

* Console setup is simple, but the NuGets for the app does not support being used as a transitive dependency and also
  generates files in the project tree which will end up being checked into source control as well as break incremental
  builds. Basically, a bit hard to use.
* Does not collect exceptions from unobserved Tasks
* Does not collect crashes from background threads on Android
* Web console is not the greatest

### <a name="#fb"></a> Firebase Crashlytics

> BUG: Currently iOS is not working on .NET 8: https://github.com/xamarin/GoogleApisForiOSComponents/issues/643

**Links:**

* Home: https://firebase.google.com/products/crashlytics
* .NET MAUI: There is no official guide since Crashlytics does not support .NET, however there are bindings and there
  are community guides. For example, Victor Hugo Garcia has a short guide: [**Firebase Crashlytics in .NET MAUI**](https://dev.to/vhugogarcia/firebase-crashlytics-in-net-maui-57jp)

**Pros:**

* Easy to set up - uses a file from the Firebase Console with all the settings
* Highly detailed analytics on Android as a result of Google Play integration
* Open source:
  * Android: https://github.com/firebase/firebase-android-sdk 
  * iOS: https://github.com/firebase/firebase-ios-sdk
  * Xamarin Bindings:
    * Android: https://github.com/xamarin/GooglePlayServicesComponents
    * iOS: https://github.com/xamarin/GoogleApisForiOSComponents

**Cons:**

* No support for Windows
* No .NET bindings for macOS yet: https://github.com/xamarin/GoogleApisForiOSComponents/issues/516
* Does not collect exceptions from unobserved Tasks
* Does not collect crashes from background threads on Android
* No simple, cross-platform API to get started, but the community has a plugin: https://github.com/TobiasBuchholz/Plugin.Firebase


### New Relic

**Links:**

* Home: https://newrelic.com
* Mobile: [**Introduction to mobile monitoring**](https://docs.newrelic.com/docs/mobile-monitoring/new-relic-mobile/get-started/introduction-mobile-monitoring)
* .NET MAUI: [**Monitor your .NET MAUI mobile app**](https://docs.newrelic.com/docs/mobile-monitoring/new-relic-mobile-maui-dotnet/monitor-your-net-maui-application)

**Pros:**

* Easy to set up
* Collects all crashes on iOS (managed/native)
* Partially open source SDKs:
  * .NET MAUI: https://github.com/newrelic/newrelic-maui-plugin
  * Android: https://github.com/newrelic/newrelic-android-agent 
  * iOS: Not open source

**Cons:**

* No support for desktop (macOS and Windows)
* Does not collect exceptions from unobserved Tasks
* Does not collect crashes from background threads on Android


### Raygun

**Links:**

* Home: https://raygun.com
* .NET MAUI: https://raygun.com/documentation/language-guides/dotnet/crash-reporting/maui

**Pros:**

* Easy setup with builder integration
* Fully open source SDKs:
    * .NET MAUI: https://github.com/MindscapeHQ/raygun4maui
    * .NET: https://github.com/MindscapeHQ/raygun4net
* Native crash reporting for Android, iOS and macOS

**Cons:**

* Does not collect exceptions from unobserved Tasks. I opened a new suggestion just in case: 
  https://raygun.com/thinktank/suggestion/185362 I also made a PR:  
  https://github.com/MindscapeHQ/raygun4maui/pull/11
* Does not report exceptions on non-UI threads on iOS: https://github.com/MindscapeHQ/raygun4maui/issues/12
* BUG? Does not report native exceptions on iOS: https://github.com/MindscapeHQ/raygun4maui/issues/13


### Sentry.io

**Links:**

* Home: https://sentry.io
* .NET MAUI: [**Sentry for Multi-platform App UI (MAUI)**](https://docs.sentry.io/platforms/dotnet/guides/maui)

**Pros:**

* Easy setup - especially the integration with the builder
* Fully open source SDKs:
  * .NET MAUI: https://github.com/getsentry/sentry-dotnet
  * Android: https://github.com/getsentry/sentry-java
  * iOS/macOS: https://github.com/getsentry/sentry-cocoa
* Native crash reporting for Android, iOS and macOS
* Catches exceptions from unobserved tasks

**Cons:**

* Profiling is not yet available for .NET MAUI
* Does not have advanced user analytics, like new vs returning users

