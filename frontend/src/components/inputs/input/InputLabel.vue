<template>
    <div class="flex">
        <label for="input" class="labelClass">{{ label }}</label>

        <input
            :type="type"
            :placeholder="placeHolder"
            :value="internValue"
            @input="$emit('update:modelValue', $event.target.value)"
            ref="myInput"
        />
    </div>
</template>

<script>
export default {
    name: "InputLabel",
    inheritedAttrs: false,
    props: {
        label: { type: String, default: "" },
        type: { type: String, default: "text" },
        placeHolder: { type: String, default: "" },
        modelValue: { type: String, default: "" },
        autoFocus: { type: Boolean, default: false },
    },
    emits: ["update:modelValue"],
    data() {
        return {
            internValue: null,
        };
    },
    watch: {
        modelValue(newValue) {
            this.internValue = newValue;
        },
    },
    mounted() {
        if (this.autoFocus) {
            this.$refs.myInput.focus();
        }
    },
};
</script>

<style lang="scss" src="./style.scss" scoped />
