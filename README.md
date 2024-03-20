# OnlypicsBot: Бот-агрегатор мемов для Telegram

[![package](https://img.shields.io/badge/support-@AntiToxic__work-blue)](https://t.me/antitoxic_work)


<center>
  <a href="https://t.me/OnlypicsBot">
    <img src="https://imgur.com/FiIw4vE" title="source: imgur.com" width="50%" height="50%" />
  </a>
</center>


**OnlypicsBot** это бот-агрегатор мемов. Главным действующим лицом здесь являются пользователи, которые публикуют свои картинки и оценивают картинки других. Главной особенностью этого бота является честная система рейтинга мемов. Отличие этого бота от большинства пабликов с мемами является то, что здесь нет главного администратора, который выбирает, какой мем опубликовать. Пользователи сами в любое время смотрят мемы и оценивают их, таким образом самые лучшие и смешные мемы определятеся самим сообществом.
```
    Главные цели проекта:
        1. Создать свободную площадку для публикаций мемов для всех желающих. 
        2. Обеспечить возможность честной оценки каждого мема, для выявления самых лучших.
        3. Сохранить, запечатлить в каждый момент времени состояние культуры, настроения общества, отображаемое через мемы.
```


## 🔨 Начало

1. Скачайте репозиторий
```shell
    git clone https://github.com/AntiToxicic/TelegramBot.git
```

2. Добавьте необходимые библиотеки, для работы с проектом

3. Создайте UserSercrets в файле TelegramBot.Api со следующим содержимым
```
{
  "TelegramBot": {
    "token" : "{token}"
  },

  "BOTANSWERS": {
    "START": "Добро пожаловать в телеграм бот Только картинки!\n\nЗагружайте свои картинки и смотрите картинки других пользователей.",
    "AWAITPICTURE": "Ждем вашу картинку",
    "ACCEPTPICTURE": "Ваша картинка принята",
    "DEFAULT": "Нет такого ответа",
    "BADPHOTODEFAULT": "Вы можете отправить только одну картинку за раз",
    "NOTREGISTEREDDEFAULT": "Телеграм бот обновился!",
    "CONTINUE": "Продолжаем",
    "NOLIKES": "Эту картинку еще не оценивали",
    "LIKESCOUNT": "Эту картинку оценили: ",
    "STATISTIC": {
      "TEMPLATE" : "Ваша статистика:",
      "LIKES" : "Лайки:",
      "UPLOADS" : "Картинок загружено:"
    },
    "RULES": {
      "RULE1" : "1. Не загружайте дубликаты",
      "RULE2" : "2. Не загружайте картинки сексуального характера",
      "RULE3" : "3. Не загружайте картинки откровенно оскорбительного характера",
      "RULE4" : "4. Наслаждайтесь"
    },

    "YOUWEREBANNED" : "Вы забанены",
    "YOURPICTUREWEREDELETED" : "Ваша картинка была удалена",
    "USERWASBANNED" : "Пользователь был забанен",
    "USERPICUTREWASDELETED" : "Картинка была удалена"
  },

  "TELEGRAMCOMMANDS": {
    "START": "/start",
    "RULES": "/rules",
    "STATISTIC": "/statistic",
    "GETPICUTRE": "\uD83D\uDC40",
    "UPLOADPICTURE": "Моя картинка",
    "GETSTART": "Понятно",
    "GETBACK": "Назад",
    "LIKE": "\uD83D\uDC4D",

    "BANUSER" : "/ban",
    "DELETEPICTURE" : "/del"
  },

  "DataBase": {
    "password": "admin",
    "name": "TelegramBot"
  },
  "PictureStorage": {
    "path": "/root/TelegramBot/Pictures/",
    "StartPicture": "/root/TelegramBot/Pictures/1.jpg"
  }
}
```

## 🚧 Стек технологий

- Target framework net 7.0
- Ef Core
- PostgreSQL
- ASP.NET

## 📦 Необходимые библиотеки

Мы используем популярные библиотеки, такие как Telegram.Bot, MediatR, и другие. Вот несколько из них:

- Microsoft.AspNetCore.Mvc.NewtonsoftJson
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools
- Npgsql.EntityFrameworkCore.PostgreSQL
- Telegram.Bot
- MediatR
- Swashbuckle.AspNetCore
