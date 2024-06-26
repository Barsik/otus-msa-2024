# Кейс
Интернет-сервис для размещения объявлений. Кейс был выбран из вариантов, предоставленных в качестве вариантов проектной работы.
Название системы - "Obavi"

# Пользовательские сценарии
Список сценариев сильно далеко не полный, но основные я постарался описать.

## Сценарий. Регистрация пользователя
**Цель:** Зарегистрировать нового пользователя в системе.

**ЕСТЬ** Новый пользователь
**И ЕСТЬ** система "Obavi"
**И** Пользователь открывает главную страницу сайта
**И** Пользователь нажимает на кнопку "Регистрация"
**И** Система отображает форму регистрации
**И** Пользователь заполняет форму, вводя имя пользователя, email и пароль
**И** Пользователь нажимает на кнопку "Зарегистрироваться"
**КОГДА** введенные данные верны
**ТОГДА** Система отображает сообщение о успешной регистрации и перенаправляет пользователя на страницу входа
**КОГДА** введенный email уже используется
**ТОГДА** Система отображает сообщение об ошибке, информируя пользователя, что email уже зарегистрирован
**КОГДА** введенный пароль не соответствует требованиям безопасности
**ТОГДА** Система отображает сообщение об ошибке, информируя пользователя, что пароль не соответствует требованиям безопасности

## Сценарий. Вход пользователя

**Цель:** Войти в систему.

**ЕСТЬ** зарегистрированный пользователь с ролью "пользователь" 
**И ЕСТЬ** система "Obavi"
**И** Пользователь открывает главную страницу сайта
**И** Пользователь нажимает на кнопку "Вход"
**И** Система отображает форму входа
**И** Пользователь вводит имя пользователя и пароль
**И** Пользователь нажимает на кнопку "Войти"
**КОГДА** введенные данные верны
**ТОГДА** Система возвращает токен и перенаправляет пользователя на главную страницу, отображая его профиль
**КОГДА** введенные данные неверны
**ТОГДА** Система отображает сообщение об ошибке, информируя пользователя, что введены неверные данные

## Сценарий. Создание объявления
**Цель:** Разместить новое объявление.

**ЕСТЬ** авторизованный пользователь с ролью "пользователь" 
**И ЕСТЬ** система "Obavi"
**И** пользователь переходит на страницу создания объявления
**И** пользователь заполняет форму - заголовок, описание, цену и категорию
**И** нажимает на кнопку Создать объявление
**КОГДА** форма заполнена корректно
**ТОГДА** пользователь видит сообщение об успешном создании объявления
**И** система переводит пользователя на страницу с его объявлениями
**КОГДА** форма заполнена некорректно
**ТОГДА** система сообщает об ошибке и информирует пользователя о необходимости корректно заполнить поля

## Сценарий. Поиск объявлений
**Цель:** Найти объявления по заданным критериям.

**ЕСТЬ** авторизованный пользователь с ролью "пользователь" 
**И ЕСТЬ** система "Obavi"
**И** пользователь открывает главную страницу сайта
**И** вводит ключевые слова в поисковую строку и/или выбирает фильтры (категория, диапазон цен)
**И** нажимает на кнопку Поиск
**КОГДА** что-то было найдено
**ТОГДА** Система отображает список объявлений, соответствующих критериям поиска
**КОГДА** не найдено ни одного объявления
**ТОГДА** система отображает сообщение о том, что по заданным критериям ничего не найдено

## Сценарий. Отправка сообщения продавцу
**Цель:** Отправить сообщение продавцу по поводу объявления.

**ЕСТЬ** Авторизованный пользователь с ролью "пользователь" и пользователь должен был найти интересующее его объявление
**И ЕСТЬ** система "Obavi"
**И** Пользователь нажимает на кнопку "Написать продавцу".
**И** Система отображает форму отправки сообщения
**И** Пользователь вводит текст сообщения и нажимает на кнопку "Отправить"
**ТОГДА** Система отображает сообщение об успешной отправке и сохраняет сообщение в истории переписки

## Сценарий. Обработка платежа
**Цель:** Оплатить размещение объявления.

**ЕСТЬ** авторизованный пользователь с ролью "пользователь" и пользователь должен был найти интересующее его объявление
**И ЕСТЬ** Объявление активно и еще не куплено
**И ЕСТЬ** система "Obavi"
**И** Пользователь переходит на страницу оплаты объявления
**И** Пользователь выбирает метод оплаты и вводит необходимые данные
**И** Пользователь нажимает на кнопку "Оплатить"
**КОГДА** платеж прошел
**ТОГДА** Система отображает сообщение об успешной оплате
**И** фиксирует в системе, что объявление было успешно куплено
**КОГДА** платеж не прошел
**ТОГДА** Система отображает сообщение об ошибке и предлагает пользователю повторить попытку или выбрать другой метод оплаты
**КОГДА** платеж прошел
**НО** обращение уже неактивно или уже было куплено
**ТОГДА** Система отображает сообщение об ошибке
**И** Возвращает денежные средства на счет пользователя


# Общую схему взаимодействия сервисов
![[obavi_schema_draft.png]]

**Исходник:**
![[obavi_schema_draft.drawio]]

# Список сервисов
### Пользовательский сервис (User Service)
**Функциональность:**

- Регистрация и аутентификация пользователей
- Управление профилями пользователей
- Управление ролями и правами доступа

### Сервис объявлений (Ad Service)
**Функциональность:**

- Создание, редактирование и удаление объявлений
- Управление категориями и тегами
- Модерация объявлений

### Поисковый сервис (Search Service)
**Функциональность:**

- Индексация объявлений
- Поиск по ключевым словам, категориям и фильтрам
- Рекомендации

### Сервис сообщений (Messaging Service)
**Функциональность:**

- Обмен сообщениями между пользователями
- Уведомления о новых сообщениях

### Сервис платежей (Payment Service)
**Функциональность:**

- Обработка платежей
- Интеграция с платежными системами
- Управление счетами и транзакциями

### Сервис уведомлений (Notification Service)
**Функциональность:**

- Уведомления о новых объявлениях, сообщениях и других событиях
- Поддержка email, SMS, push-уведомлений
- Управление настройками уведомлений пользователей

### Сервис аналитики (Analytics Service)
**Функциональность:**

- Сбор и анализ данных о пользователях и их активности
- Отчеты и дашборды для администраторов
- Анализ эффективности рекламных кампаний

### Административный сервис (Admin Service)
**Функциональность:**

- Управление пользователями и их правами
- Модерация контента
- Управление настройками системы

### Сервис отзывов и рейтингов (Review and Rating Service)
**Функциональность:**

- Управление отзывами пользователей о продавцах и покупателях
- Система рейтингов

### Взаимодействие между микросервисами
Единой точкой входа для всех клиентских запросов выступает API Gateway. Взаимодействие между сервисами можно настроить через протокол HTTP или gRPC. Для себя рассматриваю общение через HTTP.

### Использование очередей и событий
Для асинхронного взаимодействия между микросервисами можно использовать системы очередей и публикации/подписки на события (например, RabbitMQ или Apache Kafka). Предполагаю использовать Apache Kafka.

# Контракты взаимодействия сервисов
### User Service (Сервис пользователей)
#### Регистрация пользователя
**Endpoint:** `POST /users/register`

**Request:**
```json
{
  "username": "string",
  "password": "string",
  "email": "string"
}
```

**Response:**
```json
//200
{
  "userId": "string",
  "username": "string",
  "email": "string"
}
//400
{
  "message": "string"
}
```

#### Аутентификация пользователя
**Endpoint:** `POST /users/login`

**Request:**
```json
{
  "username": "string",
  "password": "string"
}
```

**Response:**
```json
{
  "token": "string"
}
```

### Ad Service (Сервис объявлений)
#### Создание объявления
**Endpoint:** `POST /ads`
**Request:**
```json
{
  "title": "string",
  "description": "string",
  "price": "number",
  "category": "string"
}
```

**Response:**
```json
//200
{
  "adId": "string"
}

//400
{
  "message": "string"
}
```

#### Обновление объявления
**Endpoint:** `PUT /ads/{adId}`

**Request:**
```json
{
  "title": "string",
  "description": "string",
  "price": "number",
  "category": "string"
}
```

**Response:**
```json
//204 no content
```

### Search Service (Сервис поиска)
#### Поиск объявлений
**Endpoint:** `GET /search`

**Request:**
```json
{
  "query": "string",
  "category": "string",
  "priceMin": "number",
  "priceMax": "number"
}
```

**Response:**
```json
[
  {
    "adId": "string",
    "title": "string",
    "description": "string",
    "price": "number",
    "userId": "string",
    "userName": "string",
    "category": "string",
    "createdAt": "string"
  }
]
```

### Messaging Service (Сервис сообщений)
#### Отправка сообщения
**Endpoint:** `POST /messages`

**Request:**
```json
{
  "recipientId": "string",
  "adId": "string",
  "message": "string"
}
```

**Response:**
```json
//200
{
  "messageId": "string",
  "sentAt": "string"
}
```

### Payment Service (Сервис платежей)
#### Обработка платежа
**Endpoint:** `POST /payments`

**Request:**
```json
{
  "adId": "string",
  "paymentMethod": "string"
}
```

**Response:**
```json
//200
{
  "paymentId": "string",
  "status": "string",
  "processedAt": "string"
}
```

### Notification Service (Сервис уведомлений)
#### Отправка уведомления
**Endpoint:** `POST /notifications`

**Request:**
```json
//200
{
  "userId": "string",
  "message": "string",
  "type": "string"
}
```

**Response:**
```json
{
  "notificationId": "string",
  "userId": "string",
  "message": "string",
  "type": "string",
  "sentAt": "string"
}
```