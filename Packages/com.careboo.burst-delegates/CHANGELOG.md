# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/) and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

# [2.0.0-pre.1](https://github.com/CareBoo/Burst.Delegates/compare/v1.2.0...v2.0.0-pre.1) (2021-04-03)


### Code Refactoring

* :fire: Remove ValueFunc, ValueAction, and use new C# 9 function pointer syntax ([e5ea11a](https://github.com/CareBoo/Burst.Delegates/commit/e5ea11aca68bf824cfc2d055b5ef23ee2feb189a))


### Performance Improvements

* :zap: Use C# 9 function pointers ([bf91f66](https://github.com/CareBoo/Burst.Delegates/commit/bf91f66dca68720a09f453c603395e71a2392620))


### BREAKING CHANGES

* Removed ValueFunc, ValueAction

# [1.2.0](https://github.com/CareBoo/Burst.Delegates/compare/v1.1.0...v1.2.0) (2021-03-10)


### Bug Fixes

* :bug: Fix BurstAction and BurstFunc so they don't throw exceptions ([8c7cc97](https://github.com/CareBoo/Burst.Delegates/commit/8c7cc97609f79700ce2485a5bfc000fc9f77600e))
* :bug: Fix missing dependency ([c84691a](https://github.com/CareBoo/Burst.Delegates/commit/c84691a29039d5bfadbc1e913145d26583489604))


### Features

* :sparkles: Add Compile implementation to Value Delegates ([24271cd](https://github.com/CareBoo/Burst.Delegates/commit/24271cd36aa308f57a8ee81c17e160e1e3fae54a))
* :sparkles: Add FunctionPointer compatible Value Delegates ([5538a6f](https://github.com/CareBoo/Burst.Delegates/commit/5538a6f44e9b0e72a7e73b33a45f47b66276016f))
* :sparkles: Add implicit conversion between BurstDelegates and ValueDelegates ([5d0f915](https://github.com/CareBoo/Burst.Delegates/commit/5d0f91533e36cc5df9f8d2deb4b36a9a824a8bd7))
* :sparkles: Introduce working generic FuncPointer ([8c8be4f](https://github.com/CareBoo/Burst.Delegates/commit/8c8be4f55b5471c516182cb0db187761ddc9b42d))

# [1.2.0-preview.5](https://github.com/CareBoo/Burst.Delegates/compare/v1.2.0-preview.4...v1.2.0-preview.5) (2020-12-17)


### Bug Fixes

* :bug: Fix missing dependency ([369826a](https://github.com/CareBoo/Burst.Delegates/commit/369826ad174b42c4b8406b84d79c648be0084aa5))

# [1.2.0-preview.4](https://github.com/CareBoo/Burst.Delegates/compare/v1.2.0-preview.3...v1.2.0-preview.4) (2020-12-16)


### Features

* :sparkles: Introduce working generic FuncPointer ([e74a2c8](https://github.com/CareBoo/Burst.Delegates/commit/e74a2c889f363cb022b3ad0268babee9f4165bca))

# [1.2.0-preview.3](https://github.com/CareBoo/Burst.Delegates/compare/v1.2.0-preview.2...v1.2.0-preview.3) (2020-12-15)


### Bug Fixes

* :bug: Fix BurstAction and BurstFunc so they don't throw exceptions ([3ea2f3c](https://github.com/CareBoo/Burst.Delegates/commit/3ea2f3c84b7c6149e3303c939cdeed5a35120c44))

# [1.2.0-preview.2](https://github.com/CareBoo/Burst.Delegates/compare/v1.2.0-preview.1...v1.2.0-preview.2) (2020-12-15)


### Features

* :sparkles: Add implicit conversion between BurstDelegates and ValueDelegates ([9d5542c](https://github.com/CareBoo/Burst.Delegates/commit/9d5542cf9beac7372877ad5a8b36423662ea99fc))

# [1.2.0-preview.1](https://github.com/CareBoo/Burst.Delegates/compare/v1.1.0...v1.2.0-preview.1) (2020-12-15)


### Features

* :sparkles: Add Compile implementation to Value Delegates ([0f2032f](https://github.com/CareBoo/Burst.Delegates/commit/0f2032f5cd5185511e7a847f2a08f73c07f96a76))
* :sparkles: Add FunctionPointer compatible Value Delegates ([1b7940b](https://github.com/CareBoo/Burst.Delegates/commit/1b7940b47064f69f0d723a0a0237f9e1320885ff))

# [1.1.0](https://github.com/CareBoo/Burst.Delegates/compare/v1.0.0...v1.1.0) (2020-10-26)


### Features

* :sparkles: Support parameterless `New` ([3b627c2](https://github.com/CareBoo/Burst.Delegates/commit/3b627c236e40a9ae96771df282e79242c448591a))

# 1.0.0 (2020-10-26)


### Features

* :sparkles: Implement struct-based API ([6110094](https://github.com/CareBoo/Burst.Delegates/commit/6110094ebcab28afac7b69e7c5e9d95eec32b1ea))

# 1.0.0-preview.1 (2020-10-26)


### Features

* :sparkles: Implement struct-based API ([6110094](https://github.com/CareBoo/Burst.Delegates/commit/6110094ebcab28afac7b69e7c5e9d95eec32b1ea))
