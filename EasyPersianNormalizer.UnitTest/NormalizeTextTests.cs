using FluentAssertions;
using PersianSearch.Normalizer;

namespace EasyPersianNormalizer.UnitTest;

public class NormalizeTextTests
{
	[Fact]
	public void NormalizerText_Should_Return_Empty_When_Input_Is_Null_Or_Empty()
	{
		string? input = null;
		input.NormalizerText().Should().BeEmpty();

		input = string.Empty;
		input.NormalizerText().Should().BeEmpty();
	}

	[Fact]
	public void NormalizerText_Should_Trim_Text_When_Config_Trim_True()
	{
		const string Input = "  سلام  ";
		var config = new NormalizerConfig { Trim = true };

		Input.NormalizerText(config).Should().Be("سلام");
	}

	[Theory]
	[InlineData("123", NumberConvertorType.ToPersian, "۱۲۳")]
	[InlineData("۱۲۳", NumberConvertorType.ToEnglish, "123")]
	[InlineData("123", NumberConvertorType.None, "123")]
	public void NormalizerText_Should_Convert_Numbers_Based_On_Config(string input, NumberConvertorType type, string expected)
	{
		var config = new NormalizerConfig { NumberConvertorType = type };
		input.NormalizerText(config).Should().Be(expected);
	}

	[Fact]
	public void NormalizerText_Should_Remove_Diacritics()
	{
		const string Input = "سَلام"; // Contains diacritic
		var config = new NormalizerConfig { RemoveDiacritics = true };

		Input.NormalizerText(config).Should().Be("سلام");
	}

	[Fact]
	public void NormalizerText_Should_Convert_Arabic_Ye_Ke()
	{
		const string Input = "يکي"; // Arabic Ye and Ke
		var config = new NormalizerConfig { ConvertArabicYeKe = true };

		Input.NormalizerText(config).Should().Be("یکی");
	}

	[Fact]
	public void NormalizerText_Should_Apply_HalfSpace_Rule()
	{
		const string Input = "ما نمی توانیم";
		var config = new NormalizerConfig { ChangeToHalfSpace = true };

		var result = Input.NormalizerText(config);

		result.Should().Be("ما نمی\u200cتوانیم");
	}

	[Fact]
	public void NormalizerText_Should_Normalize_Dashes()
	{
		const string Input = "سلام--خوبی";
		var config = new NormalizerConfig { RemoveMoreDash = true };

		Input.NormalizerText(config).Should().NotContain("--");
	}

	[Fact]
	public void NormalizerText_Should_Normalize_Dots()
	{
		const string Input = "سلام....خوبی";
		var config = new NormalizerConfig { RemoveMoreDot = true };

		Input.NormalizerText(config).Should().NotContain("....");
	}

	[Fact]
	public void NormalizerText_Should_Convert_English_Quotes()
	{
		const string Input = "\"سلام\"";
		var config = new NormalizerConfig { ConvertEnglishQuotes = true };

		Input.NormalizerText(config).Should().Be("«سلام»");
	}

	[Fact]
	public void NormalizerText_Should_Remove_Extra_Marks()
	{
		const string Input = "سلام!!!";
		var config = new NormalizerConfig { RemoveExtraMarks = true };

		Input.NormalizerText(config).Should().NotContain("!!!");
	}

	[Fact]
	public void NormalizerText_Should_Remove_Keshide()
	{
		const string Input = "ســــــلام";
		var config = new NormalizerConfig { RemoveKeshide = true };

		Input.NormalizerText(config).Should().Be("سلام");
	}

	[Fact]
	public void RemoveSpacingAndLineBreaks_Should_Collapse_Multiple_Spaces_And_LineBreaks()
	{
		// Input includes:
		// - multiple spaces
		// - multiple line breaks
		// - line break followed by spaces and ZWNJ
		const string Input = "سلام    \n\n   ‌   خوبی؟   ";

		var result = Input.NormalizerText();

		// Validate: only single spaces and at most one newline
		result.Should().Be("سلام خوبی؟");
	}

	[Fact]
	public void NormalizerText_Should_Apply_OutsideInsideSpacing()
	{
		const string Input = " ( سلام ) ";
		var config = new NormalizerConfig { OutsideInsideSpacing = true };

		var result = Input.NormalizerText(config);
		result.Should().NotContain(" (").And.NotContain(") ");
	}

	[Fact]
	public void NormalizerText_Should_Remove_Hexadecimal_Symbols()
	{
		const string Input = "سلام \x0C";
		var config = new NormalizerConfig { RemoveHexadecimalSymbols = true };

		Input.NormalizerText(config).Should().Be("سلام");
	}
}
