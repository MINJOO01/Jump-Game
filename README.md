# 🕹️ Jump Game (점프게임) 🍪

***
## 0. 소개
#### (1) 사용 언어
* C#
#### (2) 작업 시기
* 대학교 2학년 1학기 기말 개인 프로젝트
* 2021년 상반기 / 약 2주 소요
#### (3) 특징
* GUI 프로그래밍
* 소켓 프로그래밍 사용
* 클래스 다이어그램에서 최소 2번 이상 상속되는 구조
* 추상클래스와 인터페이스 필수 사용

***
## 1. 컨셉
#### (1) 주제
* 제한 시간 내에 아이템을 모두 획득해 정해진 위치까지 이동하는 게임
#### (2) 기능 및 특징
* 게임은 GUI로 구현한다.
* 소켓 프로그래밍을 이용해 여러 명이 참여 가능하도록 한다.
    * 플레이어들은 게임 도입부에서 각자 닉네임을 정해 채팅을 할 수 있으며, 이후 게임은 따로 진행한다. 
* 3개의 스테이지로 구성한다.
  * 각 스테이지의 차이점
    * 캐릭터의 상태 (hp, life)
    * 조건 (coin의 개수, item의 종류, sec)
  * 공통점  
    * 스테이지마다 2개의 모드(Easy, Hard)를 선택할 수 있다.
    * 코인은 모두 획득해야 하지만, 나머지 아이템은 그럴 필요없다.
    * enemy에 부딪히거나, second가 0이 되거나, 또는 hp가 0이 되면 Game over 되고, life가 하나 깎인다.
    * 이때, life가 0보다 크면 게임이 다시 시작되고, 그렇지 않으면 실패한 것으로 처리되어 다음 스테이지로 넘어간다.
    * item은 크게 2가지가 있다.(hp/second를 증감시키는 아이템)
#### (3) 게임의 기본 규칙
* 캐릭터를 움직여서 아이템을 모두 획득한 후 정해진 위치로 가야함
* 캐릭터를 움직이는 방법 : 상하좌우의 방향키 사용
  * ↑ : 점프
  * ↓ : 아래 방향으로 이동
  * ← : 왼쪽 방향으로 이동
  * → : 오른쪽 방향으로 이동
* 아이템 중에는 체력(hp)이나 시간(second)를 줄어들게 하는 아이템도 존재한다.
#### (4) 클래스 다이어그램     
![img1](https://github.com/MINJOO01/Jump-Game/assets/77265017/65ce891e-ecb4-43bb-9141-644010a16e09)

***
## 2. 구현 결과
#### (1) 서버
![img2](https://github.com/MINJOO01/Jump-Game/assets/77265017/7b88a593-83b0-43a5-8f8a-67879852e413)
* 서버 열리면, 텍스트박스에 “>>서버가 열렸습니다” 추가

  
![img3](https://github.com/MINJOO01/Jump-Game/assets/77265017/0f0a0ee0-dcf0-426e-ba3d-f385e42267fb)
* 클라이언트 접속 시 “>>클라이언트 연결“ 추가
* 클라이언트의 채팅 추가

#### (2) 클라이언트
![img5](https://github.com/MINJOO01/Jump-Game/assets/77265017/676a3ded-191b-4139-a845-18f02db55b68)
* 오프닝 화면
* 10초 뒤 다음으로

![img6](https://github.com/MINJOO01/Jump-Game/assets/77265017/55044141-e09e-4e4b-a1d7-0c4167b674ff)
* 시작 화면
* START 버튼 클릭 시 다음으로

![img7](https://github.com/MINJOO01/Jump-Game/assets/77265017/87a9ea69-07c3-4bc6-98de-9e13b47bdb91)

![img8](https://github.com/MINJOO01/Jump-Game/assets/77265017/926d090d-a12a-46a8-857d-92115138b6b8)
* 채팅창
* 닉네임 텍스트 박스에 내용 입력 후 [확인]버튼 또는 엔터키 누르면 텍스트 박스 내용 변경 불가능
* [서버와 연결] 버튼 눌러야 서버-클라이언트 연결
* [전송] 버튼 누르면 입력 텍스트 박스에 입력한 내용 보내짐
* [스테이지로 이동] 버튼 누르면 다음으로

![img0](https://github.com/MINJOO01/Jump-Game/assets/77265017/b77dbbe9-221b-40e5-ab88-a7c18947721c)

![img10](https://github.com/MINJOO01/Jump-Game/assets/77265017/10e949c9-ecda-4486-b4a1-e78cc8cb686a)
* 버튼 누르면, 픽쳐박스가 버튼 위치로 이동
* 0.5초 뒤 다음으로

![img11](https://github.com/MINJOO01/Jump-Game/assets/77265017/0b24a977-9cc3-461b-b041-911f06a0ab6b)
* 로딩 화면
* 3초 뒤 다음으로

![img12](https://github.com/MINJOO01/Jump-Game/assets/77265017/6f7f0dbe-089e-417d-952b-5c145bb01c79)
* 스테이지1의 모드 선택 화면
* [Easy] 버튼 누를 경우, Easy 버전 게임 실행
* [Hard] 버튼 누를 경우, Hard 버전 게임 실행

![img13](https://github.com/MINJOO01/Jump-Game/assets/77265017/733a755a-629e-4366-8baa-d27191a65a29)
![img14](https://github.com/MINJOO01/Jump-Game/assets/77265017/efcab06c-905f-4037-a4ca-5f5c74f97bc9)
![img15](https://github.com/MINJOO01/Jump-Game/assets/77265017/65431201-5ef7-4463-922e-45243161a524)
* 스테이지1 Easy 모드 실행화면 : 왼쪽부터 차례로 시작하자 마자, CLEAR, FAIL 화면

![img16](https://github.com/MINJOO01/Jump-Game/assets/77265017/fd324892-52be-45b2-8999-3a0be5f3ff28)
* 스테이지1 Easy 모드
  * 코인 6개 모두 획득해 GOAL 지점으로 가면 됨
  * enemy에 부딪히면 GAME OVER, life -1, score -100
  * GAME OVER 시 엔터 키 누르면 재시작(life>0일 때)
  * life 5개 주어짐, 0개 되면 스테이지 종료
  * coin 1개 획득하면 score +30, coin 픽쳐박스 Visible=false
  * 최고점: +180 / 최저점: -500
  * 성공, 실패 후 3초 뒤 다음 화면

![img17](https://github.com/MINJOO01/Jump-Game/assets/77265017/ebe716ca-2d16-4e9a-9438-b9231d2f7d56)
* 스테이지1 Hard 모드
  * 코인 18개 모두 획득해 GOAL 지점으로 가면 됨
  * enemy에 부딪히면 GAME OVER, life -1, score -60
  * GAME OVER 시 엔터 키 누르면 재시작(life>0일 때)
  * life 3개 주어짐, 0개 되면 스테이지 종료
  * coin 1개 획득하면 score +10, coin 픽쳐박스 Visible=false
  * 최고점: +180 / 최저점: -500
  * 성공, 실패 후 3초 뒤 다음 화면

![img18](https://github.com/MINJOO01/Jump-Game/assets/77265017/f214abe6-a43a-4f92-acee-bd2bd752f441)
![img19](https://github.com/MINJOO01/Jump-Game/assets/77265017/4492da17-cfc5-4818-b40b-8477408366ca)
* 스테이지 1->2로 넘어가는 화면
* 버튼 누르면 픽쳐박스가 버튼 위치로 이동
* 0.5초 뒤 다음으로
 
![img20](https://github.com/MINJOO01/Jump-Game/assets/77265017/3ff8ec36-3421-4cf8-9170-f814223bfff8)
![img21](https://github.com/MINJOO01/Jump-Game/assets/77265017/f6c12753-56f4-4ba3-93db-f5686b5dd9a0)
* 스테이지 2, 3 로딩화면
* 3초 뒤 다음

![img22](https://github.com/MINJOO01/Jump-Game/assets/77265017/c080ce33-e538-48c9-9598-b905cc59f94f)
![img23](https://github.com/MINJOO01/Jump-Game/assets/77265017/0e23ce78-0b25-4a57-884d-b2a0e27ab150)
* 스테이지 2, 3의 모드 선택 화면

![img24](https://github.com/MINJOO01/Jump-Game/assets/77265017/e34c79a0-8cf0-4a75-9492-b78efee53a49)
![img25](https://github.com/MINJOO01/Jump-Game/assets/77265017/0aaa2e22-0380-4ae8-838e-e08c30566aa2)
* 스테이지2 CLEAR 또는 FAIL 이후 화면
* 스테이지 2->3로 넘어가는 화면
* 버튼 누르면 픽쳐박스가 버튼 위치로 이동, 0.5초 뒤 다음으로

![img26](https://github.com/MINJOO01/Jump-Game/assets/77265017/931b230d-1345-4f74-8c0e-4bafa514a62e)
![img27](https://github.com/MINJOO01/Jump-Game/assets/77265017/c891cb94-b1c0-4ea2-8964-41df2b5f80a2)
* 스테이지3 CLEAR 또는 FAIL 이후 화면
* 스테이지 3에서 엔딩화면으로 넘어가는 화면
* 버튼 누르면 픽쳐박스가 버튼 위치로 이동, 0.5초 뒤 다음으로

![img28](https://github.com/MINJOO01/Jump-Game/assets/77265017/dd80ad80-3dfd-49ed-b75b-3b1581333919)
* 스테이지2 Easy 모드(이전 스테이지와의 차이점 위주)
  * 획득해야 하는 코인의 개수는 4개
  * 코인 1개 획득할 때마다 score +40
  * life 5개, second 60초로 주어짐
  * enemy에 부딪히거나 second 0초 되면 GAME OVER
  * GAME OVER 1번에 score -60
  * item_great 획득 시, 아이템 픽쳐박스 Visible은 False가 되고, second+30

![img29](https://github.com/MINJOO01/Jump-Game/assets/77265017/ef22fad0-7b51-4be5-8aa3-4034a25976d9)
* 스테이지2 Hard 모드(이전 스테이지와의 차이점 위주)
  * 획득해야 하는 코인의 개수는 16개
  * 코인 1개 획득할 때마다 score +10
  * life 3개, second 60초로 주어짐
  * enemy에 부딪히거나 second 0초 되면 GAME OVER
  * GAME OVER 1번에 score -100
  * item_worst 획득 시, 아이템 픽쳐박스 Visible은 False가 되고, second-30

![img30](https://github.com/MINJOO01/Jump-Game/assets/77265017/42f9711c-d7a9-4c1e-ba4a-f2b251cf24e1)   
* 스테이지3 Easy 모드(이전 스테이지와의 차이점 위주)
  * 획득해야 하는 코인의 개수는 4개
  * 코인 1개 획득할 때마다 score +10
  * life 4개 주어짐
  * GAME OVER 1번에 score -100
  * item_great 획득 시, 아이템 픽쳐박스 Visible은 False가 되고, hp +45
  * hp가 100이 되면, life +1
  * 처음 hp는 10

![img31](https://github.com/MINJOO01/Jump-Game/assets/77265017/873d9bc0-7729-4d1b-8899-b58170c1d3a9)
* 스테이지3 Hard 모드(이전 스테이지와의 차이점 위주)
  * 획득해야 하는 코인의 개수는 16개
  * 코인 1개 획득할 때마다 score +10
  * life 4개 주어짐
  * GAME OVER 1번에 score -100
  * item_worst 획득 시, 아이템 픽쳐박스 Visible은 False가 되고, hp -50
  * hp가 0이 되면, life -1
  * 처음 hp는 100

![img32](https://github.com/MINJOO01/Jump-Game/assets/77265017/5313de22-9dcc-4617-aef7-676aa41baeaf)
* 엔딩 화면
* [END] 버튼 누르면 종료
