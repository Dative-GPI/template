FROM node:lts AS build-env

ARG PROJECT

WORKDIR /app/$PROJECT

RUN pwd

COPY $PROJECT/package.json package.json
COPY $PROJECT/package-lock.json package-lock.json

RUN npm install

ENTRYPOINT npm run serve