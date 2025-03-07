FROM node:22-alpine3.20
COPY . /usr/src/client
WORKDIR /usr/src/client
RUN npm install
RUN npm install -g @angular/cli
CMD ["ng", "serve", "--host", "0.0.0.0"]
