<template>
    <div class="app">
        <main-page />
    </div>
</template>

<script>
import MainPage from "@/views/mainpage/MainPage";

export default {
    name: "App",

    components: {
        MainPage,
    },
};
</script>

<style scoped>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}
</style>
