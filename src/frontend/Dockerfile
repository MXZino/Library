FROM node:20

WORKDIR /app

COPY . .

RUN npm install -g @angular/cli
RUN npm run build
RUN yarn install

CMD ["ng", "serve", "--host", "0.0.0.0", "--disable-host-check"]
