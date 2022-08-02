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
                        v-model="wall.height"
                        type="number"
                    />
                </div>
                <div class="field">
                    <InputLabel
                        label="Largura (centímetro)"
                        v-model="wall.width"
                        type="number"
                    />
                </div>
                <div class="field">
                    <InputLabel
                        label="Portas"
                        type="Number"
                        v-model="wall.doors"
                    />
                </div>
                <div class="field">
                    <InputLabel
                        label="Janelas"
                        type="Number"
                        v-model="wall.windows"
                    />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import InputLabel from "@/components/inputs/input/InputLabel.vue";
import TitlePage from "@/components/titles/title/TitlePage.vue";
import Wall from "@/models/Wall";

export default {
    name: "WallCard",
    emits: ["update:modelValue"],
    props: {
        title: {
            type: String,
            default: "",
        },
        modelValue: {
            type: Object,
            default() {
                return {};
            },
        },
    },
    components: {
        InputLabel,
        TitlePage,
    },
    data() {
        return {
            wall: new Wall(),
        };
    },
    watch: {
        modelValue(newValue) {
            if (!newValue) return;

            this.wall = newValue;
        },
        wall: {
            handler(newValue) {
                this.$emit("update:modelValue", newValue);
            },
            deep: true,
        },
    },
};
</script>

<style lang="scss" src="./style.scss" scoped />
