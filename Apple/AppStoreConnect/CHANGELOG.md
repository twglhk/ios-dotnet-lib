# WARD GAMES/Dev Library/Web Library/.NET/Apple/App Store Connect

## [1.6.1]
- AppStoreConnectReceiptParser 추가 (영수증)
- HttpRequest 범용성 리펙토링
- Transaction Query에 묶여있던 함수 AppStoreCoonectAPIHelper로 이동

--- 
## [1.6.0]
- AppStoreServer에서 받아온 TransactionInfoResponse의 유효성을 검증하고 데이터를 추출하는 과정 추가 

---
## [1.5.0]
- Transaction Info 가져오는 데에 필요한 데이터 모델링 및 enpoint 추가

---

## [1.4.7]
### Fixed
- AppStoreConnectAPIHelper의 CreateAppStoreConnectAPIQueryEndpoint에서 QueryParam이 없을 경우 옵션 Url에 추가하지 않도록 픽스 

---
## [1.4.6]
### Fixed
- QueryParam에 값이 할당될 경우, QueryParamList에 저장되도록 변경

---
## [1.4.5]
### Updated
- AppStoreConnectClient의 생성자 Param 수정

---
## [1.4.2]
### Updated
- AppStoreConnectClientFactory에서 CreateForAWSLambda 메서드 로직 중, SSM에 접근하는 로직 async/await로 변경

---
## [1.4.1]
### 주요 업데이트
- InAppPurchaseLocalization - Attributes에 Locale 추가

---
## [1.4.0]
### 주요 업데이트
- ListAllInAppPurchasesEndPoint 관련 기능 및 데이터 모델링 추가

### Added
- ListAllLocalizationsEndpoint
- InAppPurchaseLocalizationsResponse

### Removed
- InAppPurchasLocalizationResponse 
  - 단일 항목 쿼리가 v1이어서, 현재 v2 iap id로 호환이 안 되기 때문에, 추후 API 메뉴얼에 추가되면 구현할 예정. 

---
## [1.3.2]
### 주요 업데이트
- InAppPurchaseV2 클래스가 IAppStoreConnectAPIObject를 확장함.

---
## [1.3.1]
### 주요 업데이트
- (BRAKING CHANGES) IAP 관련 클래스들의 Namespace 간소화

### Fixed
- (BRAKING CHANGES) 다음 클래스들의 Namespace가 모두 한 단계 위로 조정됨.
  - ReadPriceInformationEndPoint
  - InAppPurchasePricesResponse
    - InAppPurchases => InAppPurchasePriceSchedules
  - ReadPriceInformationParamContainer
  - ReadPriceInformationParamInclude
  - ListAllInAppPurchasesEndPoint
  - ListAllInAppPurchasesPricePointsEndpoint
  - InAppPurchasePricePoint
  - InAppPurchasePricePointAttributes
  - InAppPurchasesV2Response
  - InAppPurchaseV2
  - InAppPurchaseV2Attributes
  - FieldsInAppPurchaseLocalizations
  - ListAllInAppPurchasesParamContainer
  - ListAllInAppPurchasesParamInclude

---
## [1.3.0]
### 주요 업데이트
- InAppPurchaseLocalization 관련 데이터 모델링 클래스 추가

### Added
- InAppPurchaseLocalization
  - InAppPurchaseLocalizationAttributes
- InAppPurchaseLocalizationResponse
  - 이거는 사용 시점에서 구현할 것. 현재 미구현

---
## [1.2.0]
### 주요 업데이트 사항 요약
- AppStoreConnectClient 생성을 플랫폼에 맞게 해주는 Factory class 추가

### Added
- AppStoreConnectClientFactory 

### Fixed
- AppStoreConnectClient의 디렉토리 Common으로 변경

---
## [1.1.0]
### 주요 업데이트 사항 요약
- IAP 상품 정보를 가져올 때, 라이브러리 사용측에서 string이 아닌 모델링된 클래스와 enum 옵션을 사용할 수 있도록 리펙토링

### Added
- **AppStoreConnectQueryParamBase**
  - 모든 Query param 데이터 모델링 클래스의 베이스 클래스
  - 각 Param이 가질 수 있는 option 등이 구현되어 있음.
  - Sub class
    - **AppStoreConnectQueryParamField**
      - Query param 중, Field와 관련된 클래스의 base class
      - sub class
        - **FieldsInAppPurchaseLocalizations**
          - InAppPurchaseLocalizations include를 할 시, 필터링이 가능한 옵션을 담고 있는 클래스
    - **AppStoreConnectQueryParamInclude**
      - Query param 중, include와 관련된 클래스의 base class
      - sub class
        - **ListAllInAppPurchasesParamInclude**
          - IAP의 모든 리스트를 받아올 때 지정할 수 있는 Include option을 저장하는 클래스. 
        - **ReadPriceInformationParamInclude**
          - IAP의 가격 정보를 받아올 때, 지정할 수 있는 Include option을 저장하는 클래스.
    - **AppStoreConnectQueryParamFilter**
      - Query param 중, filter와 관련된 클래스의 base class
- **AppStoreConnectQueryParamContainer**
  - AppStoreConnectQueryParamBase의 서브 클래스를 패키징하여, API 호출 시 Endpoint로 전달할 수 있는 컨테이너 클래스의 베이스 클래스

### Fixed
  - ReadPriceInformationParam => ReadPriceParamContainer와 ReadPriceParamInclude로 기능 분할.
  - 각 Endpoint에서 container 클래스를 param으로 넘길 수 있도록 리펙토링.
  - 각 query param의 option 네이밍을 value로 변경.

---
## [1.0.0]

### 주요 업데이트 사항 요약
- AppStoreConnect에서 IAP (in app purchases)의 기본적인 정보를 얻어올 수 있는 기능들이 추가 되었음.
- 패키지 이름 및 디렉토리가 WardGames.Web.Apple.AppStoreConnect로 변경되었음. (다만 버전은 1.0.0)

### Added
- AppStoreConnectAPIHelper 추가
  - API 호출에 공통된 기능 및 유틸 기능들을 묶어 놓은 클래스 추가. 라이브러리 내부적으로 사용함.
- Newtonsoft.Json 패키지 참조 추가
- AppStoreConnectAPIResponse
  - 모든 API 호출 응답의 base 클래스 추가
- IAppStoreConnectAPIObject
  - 모든 API 호출 응답 속 데이터로 담겨서 올 수 있는 오브젝트 추가.
  - 예를 들어 included 옵션 등을 통해, 오브젝트 데이터가 추가될 수 있음.
- ReadPriceInformationEndPoint
  - App Store IAP의 가격 정보를 얻어올 수 있는 Endpoint 추가
- InAppPurchasesPricesResponse
  - ReadPriceInformationEndPoint 요청의 응답으로 역직렬화 할 수 있는 응답 클래스.
  - 세부 내용은 별도로 없고, List < included >에 가격 정보를 담아올 수 있으므로, IAP의 현재 가격은 해당 데이터 참조.
- InAppPurchasesV2 데이터 모델링 추가
  - 상품의 기본 상세 데이터를 역직렬화하기 위한 클래스
- AppStoreConnectAPIObjectConverter 추가
  - 역직렬화가 다이렉트로 되지 않는 interface를 역직렬화 하기 위한 클래스.
  - **역직렬화가 필요한데 인터페이스에 의해 확장된 클래스가 있다면 이 클래스에 반드시 추가할 것.**
- AppStoreConnectQueryParamBase 추가
  - EndPoint Url을 만들 때, Param으로 들어가는 (string, string[]) 데이터를 List로 가지고 있는 상위 클래스 추가.
- AppStoreConnectAPIResponse 내의 Included에 커스텀 JsonConver인 AppStoreConnectAPIObjectConverter가 속성으로 추가
  - List< IAppStoreConnectAPIObject > 를 역직렬화 할 수 있도록 기능 추가
- Territoy 추가
  - 요청 응답으로 받을 수 있는 지역 관련 데이터
  - **현재 사용하는 응답 데이터가 없어서, 이 데이터 사용이 필요할 시 추가해야 함.**

### Fixed
- ListAllInAppPurchasesEndPoint
  - 외부에서 사용할 때, string을 반환하지 않고 역직렬화한 클래스를 반환하도록 변경.
- 일부 역직렬화를 위한 데이터 모델링 클래스에서 Backing field를 별도로 선언하지 않고, 전부 프로퍼티 형태를 사용하도록 변경.
- 프로젝트 자체에 xml 주석이 포함되도록 설정 변경
- xml 주석이 없는 클래스들에 주석 추가
- GetAppStoreConnectAPIQueryEndpoint
- Included가 const string 으로 추가되었고, Included를 사용하는 곳에 대체되었음.

### Removed
- IAP 쿼리 과정에서 사용되지 않던 클래스들 제거
  - AppleStoreConnectInAppPurchasesAttribute.cs
  - AppleStoreConnectInAppPurchasesData.cs
  - AppleStoreConnectInAppPurchasesListResponse.cs

---
## [0.2.5]
### Fixed
- AppleStoreConnectClient
  - CreateToken()에서 JwtHeader 초기화에 들어가는 "typ" key-value 제거 
---
## [0.2.4]
### Fixed
- AppleStoreConnectClient
  - CreateToken 할 때, JwtHeader 초기화에 들어가는 중복값 제거
---
## [0.2.3]
### Fixed
- AppleStoreConnectClient
  - CreateToken 하는 방식 [Apple Developer/Generating Tokens for API Requests](https://developer.apple.com/documentation/appstoreconnectapi/generating_tokens_for_api_requests) 메뉴얼에 맞게 수정. 
---
## [0.2.2]
### Fixed
- AppleStoreConnectClient
  - CreateToken()의 암호화 알고리듬 ECDSA 알고리듬으로 변경
---
## [0.2.1]
### Fixed
- AppleStoreConnectClient
  - CreateToken()의 암호화 알고리듬이 변경되었음.
---
## [0.2.0]
### Added
- AppleStoreConnect에서 응답 받는 데이터의 모델링 클래스 추가
  - AppleStoreConnectInAppPurchasesAttribute
  - AppleStoreConnectInAppPurchasesData
  - AppleStoreConnectInAppPurchasesListResponse
---
##[0.1.0]
### Added
- AppleStoreConnectClient 추가
  - AppleStoreConnect에 API요청을 보낼 수 있는 기능을 담은 클래스