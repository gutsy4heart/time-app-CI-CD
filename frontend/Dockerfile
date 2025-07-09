FROM node:alpine

WORKDIR /app

EXPOSE 3003

COPY package*.json .

RUN npm install

COPY . .

CMD ["npm", "run", "dev"]