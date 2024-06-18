# Microservice Architecture

## ДЗ: Базовые сущности Кubernetes: ReplicaSet, Deployment, Service, Ingress

1. Клонируем репозиторий
    ```shell
    git clone git@github.com:Barsik/otus-msa-2024.git
    ```
2. Переходим в папку `Deploy`
    ```shell
    cd Deploy
    ```
3. Применяем конфигурацию
    ```shell
    kubectl apply -f.
    ```
4. Делаем туннель (в `/etc/hosts` прописать `127.0.0.1	arch.homework`)
    ```shell
    minikube tunnel
    ```
5. Переходим по ссылке http://arch.homework/health/
6. Проверяем тесты Postman https://github.com/Barsik/otus-msa-2024/tree/main/Obavi/Postman
7. Чистим за собой
    ```shell
     kubectl delete -f .
    ```

