# Клавиатурный тренажер⌨️

## Запуск в `Docker compose`-е

### Запускаем контейнеры для базы данных и приложения(Авто создание образов)
```Docker
docker compose run --rm app
```

### Останавливаем контейнеры
```Docker
docker compose down
```

### Удаляем образ `key-image`
```Docker
docker rmi postgres
docker rmi pokey-app
```