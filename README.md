# Клавиатурный тренажер⌨️

## Запуск в `Docker`-е

### Создаем образ `key-image`
```Docker
docker build -t key-image -f Dockerfile .
```

### Запуск и подключение к контейнеру(Однократный запуск) 
```Docker
docker run -it --rm key-image
```

### Удаляем образ `key-image`
```Docker
docker rmi key-image:latest
```