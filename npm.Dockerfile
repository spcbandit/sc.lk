FROM node:14-alpine as build
LABEL maintainer="Dmitriy Plaschinsky"
ARG PROJECT_DIR
ARG PROJECT_DOMAIN
WORKDIR /app
COPY ${PROJECT_DIR}/package*.json ./
COPY ${PROJECT_DIR} .
RUN npm install --progress=false && npm run build
RUN npm audit fix

FROM nginx:alpine as prod
ARG PROJECT_DIR
ARG PROJECT_DOMAIN
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /app/dist /usr/share/nginx/html
COPY --from=build /app/nginx_rewrite.conf  /etc/nginx/conf.d/
RUN sed -i 's/SERVER_NAME/'"${PROJECT_DOMAIN}"'/g' /etc/nginx/conf.d/nginx_rewrite.conf
RUN cat /etc/nginx/conf.d/nginx_rewrite.conf
