<template>
    <div class="card">
        <div class="header">
            <title-page :text="title" />
        </div>
        <div class="content">
            <div class="row">
                <div class="field">
                    <InputLabel
                        label="Altura (centímetro)"
                        v-model="internHeight"
                        type="number"
                    />
                </div>
                <div class="field">
                    <InputLabel
                        label="Largura (centímetro)"
                        v-model="internWidth"
                        type="number"
                    />
                </div>
                <div class="field">
                    <InputLabel
                        label="Portas"
                        type="Number"
                        v-model="internDoors"
                    />
                </div>
                <div class="field">
                    <InputLabel
                        label="Janelas"
                        type="Number"
                        v-model="internWindows"
                    />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import InputLabel from "@/components/inputs/input/InputLabel.vue";
import TitlePage from "@/components/titles/title/TitlePage.vue";

export default {
    name: "WallCard",
    emits: ["height", "width", "doors", "windows"],
    props: {
        title: {
            type: String,
            default: "",
        },
    },
    data() {
        return {
            internHeight: null,
            internWidth: null,
            internDoors: null,
            internWindows: null,
        };
    },
    created() {},
    watch: {
        internHeight(newValue) {
            this.$emit("height", newValue);
        },
        internWidth(newValue) {
            this.$emit("width", newValue);
        },
        internDoors(newValue) {
            this.$emit("doors", newValue);
        },
        internWindows(newValue) {
            this.$emit("windows", newValue);
        },
    },

    components: {
        InputLabel,
        TitlePage,
    },
    computed: {
        // inputWall() {
        //     this.$emit("wall", this.inputWall);
        // },
        // inputWall: {
        //     get: function () {
        //         return this.value;
        //     },
        //     set: function (newValue) {
        //         this.$emit("onChange", newValue);
        //     },
        // },
    },
};
</script>

<style lang="scss" src="./style.scss" scoped />
