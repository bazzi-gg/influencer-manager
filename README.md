# influencer-manager

[![standard-readme compliant](https://img.shields.io/badge/standard--readme-OK-green.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

등록된 인플루언서의 닉네임 변경을 확인하기 위한 백그라운드 서비스입니다.
[Database](https://github.com/bazzi-gg/database)의 [Influencer](https://github.com/bazzi-gg/database/blob/main/Bazzigg.Database/Entity/Influencer.cs) 테이블용입니다.

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainers](#maintainers)
- [Contributing](#contributing)
- [Development](#development)
- [License](#license)

## Install

```
git clone https://github.com/bazzi-gg/influencer.git
```

## Usage

[Development](#development)를 참고하세요.

## Maintainers

[@mschadev](https://github.com/mschadev)

## Contributing

[기여 하시기 전 참고 사항](./CONTRIBUTING.md)

## Development

1. `InfluencerManager/appsettings.example.json`에서 공백인 **value**값을 채웁니다.
2. 파일명을 `InfluencerManager/appsettings.example.json`에서 `TrackRecord/InfluencerManager.development.json`으로 변경합니다.
3. InfluencerManager.sln을 Rider(Jetbrains) 혹은 Visual Studio로 엽니다.

## License

[MIT](./LICENSE)
