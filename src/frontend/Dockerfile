# Stage 1
FROM node:20.9.0-alpine AS compile-image

WORKDIR /app

COPY package.json ./
RUN npm install

COPY . .

RUN npm run build -- --outputPath=./dist

# Stage 2
FROM nginx:1.20-alpine

COPY --from=compile-image /app/dist /usr/share/nginx/html

COPY ./nginx.conf /etc/nginx/conf.d/default.conf