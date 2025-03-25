const app = Vue.createApp({
    data() {
        return {
            message: "Hello from Vue inside Razor Page!"
        };
    }
});

app.component('vue-component', {
    template: `<div>
                 <h3>{{ message }}</h3>
                 <button @click="updateMessage">Click Me</button>
               </div>`,
    data() {
        return {
            message: "Vue Component inside Razor!"
        };
    },
    methods: {
        updateMessage() {
            this.message = "You clicked the button!";
        }
    }
});

app.mount("#vue-app");
